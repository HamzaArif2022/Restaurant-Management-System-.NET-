using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.IServices;
using RestaurantManagSyst.Service.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagSyst.Presentation
{
    public partial class Form_OrderList : Form
    {
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;
        private readonly IMenuItemService _menuItemService;
        private readonly IPaymentMethodService _paymentMethodService;

        private List<OrderItemDto> _currentOrderItems;
        private int _selectedOrderId = 0;

        public Form_OrderList()
        {
            InitializeComponent();
            _orderService = new OrderService();
            _paymentService = new PaymentService();
            _clientService = new ClientService();
            _employeeService = new EmployeeService();
            _menuItemService = new MenuItemService();
            _paymentMethodService = new PaymentMethodService();
            _currentOrderItems = new List<OrderItemDto>();
        }

        private void Form_OrderList_Load(object sender, EventArgs e)
        {
            LoadOrders();
            LoadClients();
            LoadEmployees();
            LoadMenuItems();
            LoadPaymentMethods();
            ConfigureDataGridViews();
            ClearOrderForm();
            UpdateTotalAmount();
        }

        private void ConfigureDataGridViews()
        {
            // Configure Orders DataGridView
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvOrders.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvOrders.ColumnHeadersHeight = 40;
            dgvOrders.RowTemplate.Height = 35;

            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 60 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClientName", HeaderText = "Client", Width = 150 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployeeName", HeaderText = "Employé", Width = 150 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TableNumber", HeaderText = "Table", Width = 80 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Statut", Width = 100 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "Total", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OrderDate", HeaderText = "Date", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });

            // Configure Order Items DataGridView
            dgvOrderItems.AutoGenerateColumns = false;
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.RowHeadersVisible = false;
            dgvOrderItems.BackgroundColor = Color.White;
            dgvOrderItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvOrderItems.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvOrderItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvOrderItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrderItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvOrderItems.ColumnHeadersHeight = 35;
            dgvOrderItems.RowTemplate.Height = 30;

            dgvOrderItems.Columns.Clear();
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Article", Width = 200 });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prix", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quantité", Width = 80 });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sous-total", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvOrderItems.Columns.Add(new DataGridViewButtonColumn { HeaderText = "Action", Width = 80, Text = "Supprimer", UseColumnTextForButtonValue = true });

            // Configure Payments DataGridView
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvPayments.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPayments.ColumnHeadersHeight = 35;
            dgvPayments.RowTemplate.Height = 30;

            dgvPayments.Columns.Clear();
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 60 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "Montant", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentMethod", HeaderText = "Méthode", Width = 150 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Tips", HeaderText = "Pourboire", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaymentTime", HeaderText = "Date", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
        }

        private void LoadOrders()
        {
            var response = _orderService.GetAllOrders();
            if (response.IsSuccess)
            {
                var orders = response.Data as List<OrderDto>;
                dgvOrders.DataSource = orders;
                lblTotalOrders.Text = $"Total: {orders?.Count ?? 0} commande(s)";
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients()
        {
            var response = _clientService.GetAllClients();
            if (response.IsSuccess)
            {
                var clients = response.Data as List<ClientDTO>;
                cmbClient.DataSource = clients;
                cmbClient.DisplayMember = "Name";
                cmbClient.ValueMember = "Id";
                cmbClient.SelectedIndex = -1;
            }
        }

        private void LoadEmployees()
        {
            var response = _employeeService.GetAllEmployees();
            if (response.IsSuccess)
            {
                var employees = response.Data as List<EmployeeDto>;
                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "Name";
                cmbEmployee.ValueMember = "Id";
                cmbEmployee.SelectedIndex = -1;
            }
        }

        private void LoadMenuItems()
        {
            var response = _menuItemService.GetAllMenuItems();
            if (response.IsSuccess)
            {
                var menuItems = response.Data as List<MenuItemDto>;
                var availableItems = menuItems.Where(m => m.IsAvailable).ToList();
                cmbMenuItem.DataSource = availableItems;
                cmbMenuItem.DisplayMember = "Name";
                cmbMenuItem.ValueMember = "Id";
                cmbMenuItem.SelectedIndex = -1;
            }
        }

        private void LoadPaymentMethods()
        {
            var response = _paymentMethodService.GetAllPaymentMethods();
            if (response.IsSuccess)
            {
                var methods = response.Data as List<PaymentMethodDto>;
                var activeMethods = methods.Where(m => m.IsActive).ToList();
                cmbPaymentMethod.DataSource = activeMethods;
                cmbPaymentMethod.DisplayMember = "Label";
                cmbPaymentMethod.ValueMember = "Label";
                cmbPaymentMethod.SelectedIndex = -1;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbMenuItem.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un article", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("La quantité doit être supérieure à 0", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = cmbMenuItem.SelectedItem as MenuItemDto;
            var quantity = (int)nudQuantity.Value;

            // Check if item already exists in order
            var existingItem = _currentOrderItems.FirstOrDefault(i => i.MenuItemId == selectedItem.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.Subtotal = existingItem.Price * existingItem.Quantity;
            }
            else
            {
                _currentOrderItems.Add(new OrderItemDto
                {
                    MenuItemId = selectedItem.Id,
                    MenuItemName = selectedItem.Name,
                    Price = selectedItem.Price,
                    Quantity = quantity,
                    Subtotal = selectedItem.Price * quantity
                });
            }

            RefreshOrderItemsGrid();
            UpdateTotalAmount();
            nudQuantity.Value = 1;
        }

        private void RefreshOrderItemsGrid()
        {
            dgvOrderItems.Rows.Clear();
            foreach (var item in _currentOrderItems)
            {
                int rowIndex = dgvOrderItems.Rows.Add(
                    item.MenuItemName,
                    item.Price,
                    item.Quantity,
                    item.Subtotal,
                    "Supprimer"
                );
                dgvOrderItems.Rows[rowIndex].Tag = item;
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = _currentOrderItems.Sum(item => item.Subtotal);
            lblTotalAmount.Text = $"Total: {total:C}";
        }

        private void dgvOrderItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) // Delete button column
            {
                var item = dgvOrderItems.Rows[e.RowIndex].Tag as OrderItemDto;
                if (item != null)
                {
                    _currentOrderItems.Remove(item);
                    RefreshOrderItemsGrid();
                    UpdateTotalAmount();
                }
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (_currentOrderItems.Count == 0)
            {
                MessageBox.Show("Veuillez ajouter au moins un article à la commande", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbClient.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un client", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un employé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTableNumber.Text))
            {
                MessageBox.Show("Veuillez entrer un numéro de table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var orderDto = new OrderDto
            {
                ClientId = (int)cmbClient.SelectedValue,
                EmployeeId = (int)cmbEmployee.SelectedValue,
                TableNumber = int.Parse(txtTableNumber.Text),
                Notes = txtNotes.Text,
                Status = "Pending",
                TotalAmount = _currentOrderItems.Sum(item => item.Subtotal)
            };

            var response = _orderService.CreateOrder(orderDto, _currentOrderItems);
            if (response.IsSuccess)
            {
                MessageBox.Show("Commande créée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearOrderForm();
                LoadOrders();
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearOrderForm()
        {
            cmbClient.SelectedIndex = -1;
            cmbEmployee.SelectedIndex = -1;
            txtTableNumber.Clear();
            txtNotes.Clear();
            _currentOrderItems.Clear();
            RefreshOrderItemsGrid();
            UpdateTotalAmount();
            nudQuantity.Value = 1;
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            ClearOrderForm();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var order = dgvOrders.SelectedRows[0].DataBoundItem as OrderDto;
                if (order != null)
                {
                    _selectedOrderId = order.Id;

                    // Charger les paiements pour cette commande
                    LoadPaymentsForOrder(order.Id);

                    // Afficher/Masquer le panel de paiement selon le statut
                    if (order.Status == "Completed" || order.Status == "Cancelled")
                    {
                        pnlPayment.Visible = true;
                    }
                    else
                    {
                        pnlPayment.Visible = false;
                    }

                    // Mettre à jour le ComboBox de statut
                    cmbStatus.SelectedItem = order.Status;
                }
            }
            else
            {
                // Aucune commande sélectionnée
                _selectedOrderId = 0;
                pnlPayment.Visible = false;
                dgvPayments.DataSource = null;
            }
        }
        private void LoadPaymentsForOrder(int orderId)
        {
            var response = _paymentService.GetPaymentsByOrderId(orderId);
            if (response.IsSuccess)
            {
                var payments = response.Data as List<PaymentDto>;
                dgvPayments.DataSource = payments;
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une méthode de paiement", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPaymentAmount.Text) || !decimal.TryParse(txtPaymentAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Veuillez entrer un montant valide", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal? tips = null;
            if (!string.IsNullOrWhiteSpace(txtTips.Text) && decimal.TryParse(txtTips.Text, out decimal tipsValue))
            {
                tips = tipsValue;
            }

            var paymentDto = new PaymentDto
            {
                OrderId = _selectedOrderId,
                Amount = amount,
                PaymentMethod = cmbPaymentMethod.SelectedValue?.ToString(),
                Tips = tips
            };

            var response = _paymentService.AddPayment(paymentDto);
            if (response.IsSuccess)
            {
                MessageBox.Show("Paiement ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPaymentAmount.Clear();
                txtTips.Clear();
                LoadPaymentsForOrder(_selectedOrderId);
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un statut", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var response = _orderService.UpdateOrderStatus(_selectedOrderId, cmbStatus.SelectedItem.ToString());
            if (response.IsSuccess)
            {
                MessageBox.Show("Statut mis à jour avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande à supprimer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette commande?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var response = _orderService.DeleteOrder(_selectedOrderId);
                if (response.IsSuccess)
                {
                    MessageBox.Show("Commande supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _selectedOrderId = 0;
                    LoadOrders();
                    dgvPayments.DataSource = null;
                }
                else
                {
                    MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadOrders();
            }
            else
            {
                var response = _orderService.SearchOrders(txtSearch.Text);
                if (response.IsSuccess)
                {
                    var orders = response.Data as List<OrderDto>;
                    dgvOrders.DataSource = orders;
                }
            }
        }

        private void cmbMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenuItem.SelectedItem is MenuItemDto selectedItem)
            {
                lblItemPrice.Text = $"Prix: {selectedItem.Price:C}";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
