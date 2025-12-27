using RestaurantManagSyst.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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

        public Form_Dashboard()
        {
            InitializeComponent();
            _clientService = new ClientService();
            _employeeService = new EmployeeService();
            _paymentMethodService = new PaymentMethodService();
            _menuItemService = new MenuItemService();
            _orderService = new OrderService();
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
            RoundPanelCorners();
        }

        private void LoadDashboardData()
        {
            // Load Clients statistics
            var clientsResponse = _clientService.GetAllClients();
            if (clientsResponse.IsSuccess)
            {
                var clients = clientsResponse.Data as List<Service.DTOs.ClientDTO>;
                lblTotalClients.Text = clients?.Count.ToString() ?? "0";
            }

            // Load Employees statistics
            var employeesResponse = _employeeService.GetAllEmployees();
            if (employeesResponse.IsSuccess)
            {
                var employees = employeesResponse.Data as List<Service.DTOs.EmployeeDto>;
                lblTotalEmployees.Text = employees?.Count.ToString() ?? "0";
            }

            // Load Payment Methods statistics
            var paymentMethodsResponse = _paymentMethodService.GetAllPaymentMethods();
            if (paymentMethodsResponse.IsSuccess)
            {
                var paymentMethods = paymentMethodsResponse.Data as List<Service.DTOs.PaymentMethodDto>;
                lblTotalPaymentMethods.Text = paymentMethods?.Count.ToString() ?? "0";
                lblActivePaymentMethods.Text = paymentMethods?.Count(p => p.IsActive).ToString() ?? "0";
            }

            // Load Menu Items (Products) statistics
            var menuItemsResponse = _menuItemService.GetAllMenuItems();
            if (menuItemsResponse.IsSuccess)
            {
                var menuItems = menuItemsResponse.Data as List<Service.DTOs.MenuItemDto>;
                lblTotalProducts.Text = menuItems?.Count.ToString() ?? "0";
                lblActiveProducts.Text = menuItems?.Count(m => m.IsAvailable).ToString() ?? "0";
            }

            // Load Orders statistics
            var ordersResponse = _orderService.GetAllOrders();
            if (ordersResponse.IsSuccess)
            {
                var orders = ordersResponse.Data as List<Service.DTOs.OrderDto>;
                lblTotalOrders.Text = orders?.Count.ToString() ?? "0";
                lblCompletedOrders.Text = orders?.Count(o => o.Status == "Completed").ToString() ?? "0";
                lblPendingOrders.Text = orders?.Count(o => o.Status == "Pending").ToString() ?? "0";
            }

            // Load Users statistics (using CurrentUser for now)
            lblTotalUsers.Text = "2"; // You can implement a UserService to get actual count
        }

        private void RoundPanelCorners()
        {
            // Round the stat card panels
            RoundPanel(pnlClientsCard, 15);
            RoundPanel(pnlEmployeesCard, 15);
            RoundPanel(pnlPaymentMethodsCard, 15);
            RoundPanel(pnlProductsCard, 15);
            RoundPanel(pnlUsersCard, 15);
            RoundPanel(pnlOrdersCard, 15);
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
        }
    }
}
