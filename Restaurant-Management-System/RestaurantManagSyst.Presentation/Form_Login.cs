using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.IServices;
using RestaurantManagSyst.Service.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RestaurantManagSyst.Presentation
{
    public partial class Form_Login : Form
    {
        private readonly IAuthService _authService;
        private bool _isPasswordVisible = false;

        public Form_Login()
        {
            InitializeComponent();
            _authService = new AuthService();

            // Event handlers
            this.KeyPreview = true;
            this.KeyPress += Form_Login_KeyPress;
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            // Arrondir les coins du formulaire
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Arrondir 
            RoundControl(btnLogin, 10);
            RoundControl(pnlUsernameContainer, 10);
            RoundControl(pnlPasswordContainer, 10);

       
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void Form_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformLogin();
                e.Handled = true;
            }
        }

        private void PerformLogin()
        {
            // Masquer le message d'erreur précédent
            lblError.Visible = false;

            // Validation basique
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Veuillez entrer votre nom d'utilisateur");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Veuillez entrer votre mot de passe");
                txtPassword.Focus();
                return;
            }

            // Désactiver le bouton pendant la connexion
            btnLogin.Enabled = false;
            btnLogin.Text = "Connexion...";

            // Appel au service d'authentification
            var response = _authService.Login(txtUsername.Text, txtPassword.Text);

            // Réactiver le bouton
            btnLogin.Enabled = true;
            btnLogin.Text = "Se connecter";

            if (response.IsSuccess)
            {
                // Récupérer l'utilisateur connecté
                var user = response.Data as UserDto;
                CurrentUser.User = user;

                // Ouvrir le formulaire principal
                this.Hide();
                Form_Main mainForm = new Form_Main();
                mainForm.FormClosed += MainForm_FormClosed;
                mainForm.Show();
            }
            else
            {
                ShowError(response.Message);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Quand le formulaire principal se ferme, fermer l'application
            this.Close();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
          
            _isPasswordVisible = !_isPasswordVisible;
            txtPassword.UseSystemPasswordChar = !_isPasswordVisible;
            btnShowPassword.Text = _isPasswordVisible ? "🙈" : "👁";
        }

    
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(60, 120, 240);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(94, 148, 255);
        }

      
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(255, 128, 128);
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(64, 64, 64);
        }

        // Méthodes pour arrondir les contrôles
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private void RoundControl(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(
                0, 0, control.Width, control.Height, radius, radius));
        }
    }

    public static class CurrentUser
    {
        public static UserDto User { get; set; }

        public static bool IsAdmin()
        {
            return User != null && User.Role == "Admin";
        }

        public static bool IsCashier()
        {
            return User != null && User.Role == "Cashier";
        }

        public static void Logout()
        {
            User = null;
        }
    }
}