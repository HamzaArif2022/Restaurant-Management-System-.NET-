using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

using DrawingImage = System.Drawing.Image;

namespace RestaurantManagSyst.Presentation
{
    public partial class Form_Main : Form
    {
        // Pour déplacer la fenêtre
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Button _activeButton;
        private Form _activeForm;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            // Afficher les informations utilisateur
            lblUsername.Text = CurrentUser.User.Username;
            lblUserRole.Text = CurrentUser.User.Role;

            // Charger l'image selon le rôle
            LoadUserAvatar();

            // Configurer les permissions selon le rôle
            ConfigurePermissions();

            // Charger le dashboard par défaut
            btnDashboard.PerformClick();
        }

        private void LoadUserAvatar()
        {
            try
            {
                // Charger l'image depuis les resources embarquées
                if (CurrentUser.IsCashier())
                {
                    picUser.Image = Properties.Resources.cashier_logo;
                }
                else
                {
                    picUser.Image = Properties.Resources.admin_logo;
                }

                picUser.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erreur chargement avatar: {ex.Message}\n\nUtilisation d'un avatar par défaut.",
                    "Avertissement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                SetDefaultAvatar();
            }
        }
        private void SetDefaultAvatar()
        {
            // Créer une image par défaut avec initiales
            Bitmap defaultImage = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(defaultImage))
            {
                // Fond coloré selon le rôle
                Color bgColor = CurrentUser.IsCashier()
                    ? Color.FromArgb(155, 89, 182)  // Violet pour Cashier
                    : Color.FromArgb(52, 152, 219); // Bleu pour Admin

                g.Clear(bgColor);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Dessiner un cercle
                g.FillEllipse(new SolidBrush(bgColor), 0, 0, 64, 64);

                // Dessiner les initiales
                string initials = GetUserInitials();
                using (Font font = new Font("Segoe UI", 24, FontStyle.Bold))
                {
                    SizeF textSize = g.MeasureString(initials, font);
                    PointF textPosition = new PointF(
                        (64 - textSize.Width) / 2,
                        (64 - textSize.Height) / 2
                    );
                    g.DrawString(initials, font, Brushes.White, textPosition);
                }
            }

            picUser.Image = defaultImage;
            picUser.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private string GetUserInitials()
        {
            string username = CurrentUser.User.Username;
            if (string.IsNullOrEmpty(username))
                return "??";

            if (username.Length == 1)
                return username.ToUpper();

            return username.Substring(0, 2).ToUpper();
        }

        private void ConfigurePermissions()
        {
            if (CurrentUser.IsCashier())
            {
                btnEmployees.Visible = false;      // ❌ Gestion des Employés
                btnClients.Visible = false;        // ❌ Gestion des Clients
                btnInventory.Visible = false;      // ❌ Inventaire
                btnPaymentMethods.Visible = false; // ❌ Méthodes de Paiement

                // Les caissiers ont accès à :
                btnIngredients.Visible = true;    // ✅ Ingrédients
                btnDashboard.Visible = true;       // ✅ Tableau de bord
                btnOrders.Visible = true;          // ✅ Commandes
                btnMenuItems.Visible = true;       // ✅ Menu (lecture seule recommandée)
            }
            else if (CurrentUser.IsAdmin())
            {
                // Les admins ont accès à tout
                btnDashboard.Visible = true;
                btnOrders.Visible = true;
                btnClients.Visible = true;
                btnEmployees.Visible = true;
                btnMenuItems.Visible = true;
                btnIngredients.Visible = true;
                btnInventory.Visible = true;
                btnPaymentMethods.Visible = true;
            }
        }

        // Méthode pour ouvrir un formulaire dans le panel content
        private void OpenChildForm(Form childForm, string title)
        {
            // Fermer le formulaire actif
            if (_activeForm != null)
                _activeForm.Close();

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // Mettre à jour le titre
            lblFormTitle.Text = title;
        }

        // Activer/Désactiver le style du bouton
        private void ActivateButton(Button button)
        {
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.FromArgb(41, 53, 65);
            }

            _activeButton = button;
            button.BackColor = Color.FromArgb(94, 148, 255);
        }

        // Events des boutons du menu
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            OpenChildForm(new Form_Dashboard(), "📊 Tableau de bord");
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ActivateButton(btnOrders);
            OpenChildForm(new Form_OrderList(), "🛒 Commandes");
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            ActivateButton(btnClients);
            OpenChildForm(new Form_ClientList(), "👥 Gestion des Clients");
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            ActivateButton(btnEmployees);
            OpenChildForm(new Form_EmployeeList(), "👨‍🍳 Gestion des Employés");
        }

        private void btnMenuItems_Click(object sender, EventArgs e)
        {
            ActivateButton(btnMenuItems);
            OpenChildForm(new Form_MenuItemList(), "🍔 Gestion du Menu");
        }

        private void btnIngredients_Click(object sender, EventArgs e)
        {
            ActivateButton(btnIngredients);
            OpenChildForm(new Form_IngredientList(), "🧂 Gestion des Ingrédients");
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ActivateButton(btnInventory);
            OpenChildForm(new Form_Inventory(), "📦 Inventaire");
        }

        private void btnPaymentMethods_Click(object sender, EventArgs e)
        {
            ActivateButton(btnPaymentMethods);
            OpenChildForm(new Form_PaymentMethodList(), "💳 Méthodes de Paiement");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Voulez-vous vraiment vous déconnecter ?",
                "Déconnexion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                CurrentUser.Logout();

                // Masquer le formulaire principal
                this.Hide();

                Form_Login loginForm = new Form_Login();
                DialogResult dialogResult = loginForm.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    
                    ConfigurePermissions();
                    this.Show();
                    btnDashboard.PerformClick(); // Recharger le dashboard
                }
                if (result == DialogResult.Yes)
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        // Effets hover sur les boutons du menu
        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != _activeButton)
            {
                btn.BackColor = Color.FromArgb(52, 73, 94);
            }
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != _activeButton)
            {
                btn.BackColor = Color.FromArgb(41, 53, 65);
            }
        }

        // Contrôles de fenêtre
        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(64, 64, 64);
        }

        // Déplacer la fenêtre
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}