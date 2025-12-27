using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

            // Configurer les permissions selon le rôle
            ConfigurePermissions();

            // Charger le dashboard par défaut
            btnDashboard.PerformClick();
        }

        private void ConfigurePermissions()
        {
            // Temporarily show all buttons for testing
            // Uncomment the code below to enforce role-based permissions
            
            /*
            if (CurrentUser.IsCashier())
            {
                // Les caissiers n'ont pas accès à certaines fonctionnalités
                btnEmployees.Visible = false;
                btnInventory.Visible = false;
                btnPaymentMethods.Visible = false;
            }
            */
        }

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
            OpenChildForm(new Form_InventoryList(), "📦 Inventaire");
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
                Form_Login loginForm = new Form_Login();
                loginForm.Show();
                this.Close();
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
            Application.Exit();
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

        private void Form_Main_Load_1(object sender, EventArgs e)
        {

        }
    }
}