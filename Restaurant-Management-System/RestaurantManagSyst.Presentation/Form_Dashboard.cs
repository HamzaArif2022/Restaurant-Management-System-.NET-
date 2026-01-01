using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagSyst.Presentation
{
    public partial class Form_Dashboard : Form
    {
        private readonly ClientService _clientService;
        private readonly EmployeeService _employeeService;
        private readonly PaymentMethodService _paymentMethodService;
        private readonly MenuItemService _menuItemService;
        private readonly OrderService _orderService;
        private readonly PaymentService _paymentService;

        public Form_Dashboard()
        {
            InitializeComponent();
            _clientService = new ClientService();
            _employeeService = new EmployeeService();
            _paymentMethodService = new PaymentMethodService();
            _menuItemService = new MenuItemService();
            _orderService = new OrderService();
            _paymentService = new PaymentService();
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            // Configurer l'affichage selon le rôle
            ConfigureByRole();

            LoadDashboardData();
            RoundPanelCorners();
        }

        private void ConfigureByRole()
        {
            if (CurrentUser.IsCashier())
            {
                // Caissier : Afficher seulement certains panels
                pnlOrdersCard.Visible = true;         // ✅ Total Commandes
                pnlPaymentMethodsCard.Visible = true; // ✅ Méthodes de Paiement
                pnlProductsCard.Visible = true;       // ✅ Total Produits

                // Masquer les autres panels
                pnlClientsCard.Visible = false;       // ❌ Total Clients
                pnlEmployeesCard.Visible = false;     // ❌ Total Employés
                pnlUsersCard.Visible = false;         // ❌ Total Utilisateurs
                pnlPaymentsByMethodCard.Visible = false; // ❌ Paiements Reçus

                // Repositionner les panels visibles pour Cashier
                RepositionPanelsForCashier();
            }
            else if (CurrentUser.IsAdmin())
            {
                // Admin : Afficher tous les panels
                pnlOrdersCard.Visible = true;
                pnlClientsCard.Visible = true;
                pnlEmployeesCard.Visible = true;
                pnlPaymentMethodsCard.Visible = true;
                pnlProductsCard.Visible = true;
                pnlUsersCard.Visible = true;
                pnlPaymentsByMethodCard.Visible = true;
            }
        }

        private void RepositionPanelsForCashier()
        {
            // Réorganiser les 3 panels pour le Caissier
            int startX = 25;
            int startY = 22;
            int panelWidth = 333;
            int panelHeight = 257;
            int spacing = 40;

            // Disposition en ligne horizontale (3 panels côte à côte)
            pnlOrdersCard.Location = new Point(startX, startY);
            pnlProductsCard.Location = new Point(startX + panelWidth + spacing, startY);
            pnlPaymentMethodsCard.Location = new Point(startX + (panelWidth + spacing) * 2, startY);
        }


        private void LoadDashboardData()
        {
            // Load Clients statistics (Admin seulement)
            if (CurrentUser.IsAdmin() && pnlClientsCard.Visible)
            {
                var clientsResponse = _clientService.GetAllClients();
                if (clientsResponse.IsSuccess)
                {
                    var clients = clientsResponse.Data as List<ClientDTO>;
                    lblTotalClients.Text = clients?.Count.ToString() ?? "0";
                }
            }

            // Load Employees statistics (Admin seulement)
            if (CurrentUser.IsAdmin() && pnlEmployeesCard.Visible)
            {
                var employeesResponse = _employeeService.GetAllEmployees();
                if (employeesResponse.IsSuccess)
                {
                    var employees = employeesResponse.Data as List<EmployeeDto>;
                    lblTotalEmployees.Text = employees?.Count.ToString() ?? "0";
                }
            }

            // Load Payment Methods statistics (Tous)
            if (pnlPaymentMethodsCard.Visible)
            {
                var paymentMethodsResponse = _paymentMethodService.GetAllPaymentMethods();
                if (paymentMethodsResponse.IsSuccess)
                {
                    var paymentMethods = paymentMethodsResponse.Data as List<PaymentMethodDto>;
                    lblTotalPaymentMethods.Text = paymentMethods?.Count.ToString() ?? "0";
                    lblActivePaymentMethods.Text = paymentMethods?.Count(p => p.IsActive).ToString() ?? "0";
                }
            }

            // Load Menu Items (Products) statistics (Tous)
            if (pnlProductsCard.Visible)
            {
                var menuItemsResponse = _menuItemService.GetAllMenuItems();
                if (menuItemsResponse.IsSuccess)
                {
                    var menuItems = menuItemsResponse.Data as List<MenuItemDto>;
                    lblTotalProducts.Text = menuItems?.Count.ToString() ?? "0";
                    lblActiveProducts.Text = menuItems?.Count(m => m.IsAvailable).ToString() ?? "0";
                }
            }

            // Load Orders statistics (Tous)
            if (pnlOrdersCard.Visible)
            {
                var ordersResponse = _orderService.GetAllOrders();
                if (ordersResponse.IsSuccess)
                {
                    var orders = ordersResponse.Data as List<OrderDto>;
                    lblTotalOrders.Text = orders?.Count.ToString() ?? "0";
                    lblCompletedOrders.Text = orders?.Count(o => o.Status == "Completed").ToString() ?? "0";
                    lblPendingOrders.Text = orders?.Count(o => o.Status == "Pending").ToString() ?? "0";
                    lblPendingOrders.Text = orders?.Count(o => o.Status == "Pending").ToString() ?? "0";
                }
            }

            // Load Users statistics (Admin seulement)
            if (CurrentUser.IsAdmin() && pnlUsersCard.Visible)
            {
                lblTotalUsers.Text = "4"; // Nassim, Hamza, Meriem, Houda
            }

            // Load Payments By Method statistics (Tous)
            if (pnlPaymentsByMethodCard.Visible)
            {
                LoadPaymentsByMethod();
            }
        }

        private void LoadPaymentsByMethod()
        {
            try
            {
                var paymentsResponse = _paymentService.GetAllPayments();

                if (paymentsResponse.IsSuccess)
                {
                    var payments = paymentsResponse.Data as List<PaymentDto>;

                    if (payments != null && payments.Any())
                    {
                        // Calculer le total par méthode de paiement
                        var cashTotal = payments
                            .Where(p => p.PaymentMethod != null && p.PaymentMethod.Equals("Espèces", StringComparison.OrdinalIgnoreCase))
                            .Sum(p => p.Amount);

                        var cardTotal = payments
                            .Where(p => p.PaymentMethod != null && p.PaymentMethod.Equals("Carte Bancaire", StringComparison.OrdinalIgnoreCase))
                            .Sum(p => p.Amount);

                        var mobileTotal = payments
                            .Where(p => p.PaymentMethod != null && p.PaymentMethod.Equals("Paiement Mobile", StringComparison.OrdinalIgnoreCase))
                            .Sum(p => p.Amount);

                        // Afficher les résultats avec formatage
                        lblCashTotal.Text = $"💵 Espèces\n{cashTotal:N2} MAD";
                        lblCardTotal.Text = $"💳 Carte Bancaire\n{cardTotal:N2} MAD";
                        lblMobileTotal.Text = $"📱 Paiement Mobile\n{mobileTotal:N2} MAD";
                    }
                    else
                    {
                        lblCashTotal.Text = "💵 Espèces\n0,00 MAD";
                        lblCardTotal.Text = "💳 Carte Bancaire\n0,00 MAD";
                        lblMobileTotal.Text = "📱 Paiement Mobile\n0,00 MAD";
                    }
                }
                else
                {
                    lblCashTotal.Text = "💵 Espèces\n0,00 MAD";
                    lblCardTotal.Text = "💳 Carte Bancaire\n0,00 MAD";
                    lblMobileTotal.Text = "📱 Paiement Mobile\n0,00 MAD";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erreur technique lors du chargement des paiements : {ex.Message}",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                lblCashTotal.Text = "💵 Espèces\n0,00 MAD";
                lblCardTotal.Text = "💳 Carte Bancaire\n0,00 MAD";
                lblMobileTotal.Text = "📱 Paiement Mobile\n0,00 MAD";
            }
        }

        private void RoundPanelCorners()
        {
            // Round only visible panels
            if (pnlClientsCard.Visible)
                RoundPanel(pnlClientsCard, 15);

            if (pnlEmployeesCard.Visible)
                RoundPanel(pnlEmployeesCard, 15);

            if (pnlPaymentMethodsCard.Visible)
                RoundPanel(pnlPaymentMethodsCard, 15);

            if (pnlProductsCard.Visible)
                RoundPanel(pnlProductsCard, 15);

            if (pnlUsersCard.Visible)
                RoundPanel(pnlUsersCard, 15);

            if (pnlOrdersCard.Visible)
                RoundPanel(pnlOrdersCard, 15);

            if (pnlPaymentsByMethodCard.Visible)
                RoundPanel(pnlPaymentsByMethodCard, 15);
        }

        private void RoundPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radius, panel.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
            MessageBox.Show(
                "Tableau de bord actualisé avec succès!",
                "Actualisation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}