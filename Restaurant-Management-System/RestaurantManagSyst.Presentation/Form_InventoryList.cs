using RestaurantManagSyst.Service.IServices;
using RestaurantManagSyst.Service.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagSyst.Presentation
{
    public partial class Form_Inventory : Form
    {
        private readonly IInventoryService _inventoryService;

        public Form_Inventory()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
        }

        private void Form_Inventory_Load(object sender, EventArgs e)
        {
            ConfigureDataGridViews();
            LoadInventoryData();
        }

        #region Configuration Methods

        private void ConfigureDataGridViews()
        {
            // Configure Products DataGridView
            ConfigureProductsGrid();

            // Configure Ingredients DataGridView
            ConfigureIngredientsGrid();
        }

        private void ConfigureProductsGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProducts.DefaultCellStyle.BackColor = Color.White;
            dgvProducts.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvProducts.ColumnHeadersHeight = 40;
            dgvProducts.RowTemplate.Height = 35;
            dgvProducts.EnableHeadersVisualStyles = false;

            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id",
                Width = 60,
                Visible = false
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Produit",
                HeaderText = "Nom du Produit",
                Name = "Produit",
                Width = 300
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Quantité",
                Name = "Quantity",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReorderLevel",
                HeaderText = "Seuil de Réapprovisionnement",
                Name = "ReorderLevel",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastUpdated",
                HeaderText = "Dernière Mise à Jour",
                Name = "LastUpdated",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm"
                }
            });

            // Add Status Column (calculated)
            var statusColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Statut",
                Name = "Status",
                Width = 150,
                ReadOnly = true
            };
            dgvProducts.Columns.Add(statusColumn);
        }

        private void ConfigureIngredientsGrid()
        {
            dgvIngredients.AutoGenerateColumns = false;
            dgvIngredients.AllowUserToAddRows = false;
            dgvIngredients.AllowUserToDeleteRows = false;
            dgvIngredients.ReadOnly = true;
            dgvIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngredients.MultiSelect = false;
            dgvIngredients.RowHeadersVisible = false;
            dgvIngredients.BackgroundColor = Color.White;
            dgvIngredients.BorderStyle = BorderStyle.None;
            dgvIngredients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvIngredients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 204, 113);
            dgvIngredients.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvIngredients.DefaultCellStyle.BackColor = Color.White;
            dgvIngredients.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvIngredients.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvIngredients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvIngredients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvIngredients.ColumnHeadersHeight = 40;
            dgvIngredients.RowTemplate.Height = 35;
            dgvIngredients.EnableHeadersVisualStyles = false;

            dgvIngredients.Columns.Clear();

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IngredientId",
                HeaderText = "ID",
                Name = "IngredientId",
                Width = 60,
                Visible = false
            });

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nom de l'Ingrédient",
                Name = "Name",
                Width = 300
            });

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Quantité",
                Name = "Quantity",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Format = "N2"
                }
            });

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unit",
                HeaderText = "Unité",
                Name = "Unit",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReorderLevel",
                HeaderText = "Seuil de Réapprovisionnement",
                Name = "ReorderLevel",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "N2"
                }
            });

            // Add Status Column (calculated)
            var statusColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Statut",
                Name = "Status",
                Width = 150,
                ReadOnly = true
            };
            dgvIngredients.Columns.Add(statusColumn);
        }

        #endregion

        #region Data Loading Methods

        private void LoadInventoryData()
        {
            LoadProductInventory();
            LoadIngredientInventory();
        }

        private void LoadProductInventory()
        {
            var response = _inventoryService.GetProductInventory();

            if (response.IsSuccess)
            {
                var products = response.Data as System.Collections.IList;
                dgvProducts.DataSource = products;

                // Update status column for each row
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.Cells["Quantity"].Value != null && row.Cells["ReorderLevel"].Value != null)
                    {
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        int reorderLevel = Convert.ToInt32(row.Cells["ReorderLevel"].Value);

                        if (quantity == 0)
                        {
                            row.Cells["Status"].Value = "🔴 Rupture";
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(231, 76, 60);
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        }
                        else if (quantity <= reorderLevel)
                        {
                            row.Cells["Status"].Value = "⚠️ Faible";
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(241, 196, 15);
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        }
                        else
                        {
                            row.Cells["Status"].Value = "✅ OK";
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(46, 204, 113);
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        }
                    }
                }

                lblProductsCount.Text = $"Total: {dgvProducts.Rows.Count} produit(s)";
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIngredientInventory()
        {
            var response = _inventoryService.GetIngredientInventory();

            if (response.IsSuccess)
            {
                var ingredients = response.Data as System.Collections.IList;
                dgvIngredients.DataSource = ingredients;

                // Update status column for each row
                foreach (DataGridViewRow row in dgvIngredients.Rows)
                {
                    if (row.Cells["Quantity"].Value != null && row.Cells["ReorderLevel"].Value != null)
                    {
                        decimal quantity = Convert.ToDecimal(row.Cells["Quantity"].Value);
                        decimal? reorderLevel = row.Cells["ReorderLevel"].Value == DBNull.Value
                            ? (decimal?)null
                            : Convert.ToDecimal(row.Cells["ReorderLevel"].Value);

                        if (quantity == 0)
                        {
                            row.Cells["Status"].Value = "🔴 Rupture";
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(231, 76, 60);
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        }
                        else if (reorderLevel.HasValue && quantity <= reorderLevel.Value)
                        {
                            row.Cells["Status"].Value = "⚠️ Faible";
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(241, 196, 15);
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        }
                        else
                        {
                            row.Cells["Status"].Value = "✅ OK";
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(46, 204, 113);
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        }
                    }
                }

                lblIngredientsCount.Text = $"Total: {dgvIngredients.Rows.Count} ingrédient(s)";
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInventoryData();
            MessageBox.Show("Inventaire actualisé avec succès!", "Actualisation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProducts.Rows[e.RowIndex];
                int productInventoryId = Convert.ToInt32(row.Cells["Id"].Value);
                string productName = row.Cells["Produit"].Value.ToString();
                int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                ShowUpdateProductQuantityDialog(productInventoryId, productName, currentQuantity);
            }
        }

        private void dgvIngredients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvIngredients.Rows[e.RowIndex];
                int ingredientId = Convert.ToInt32(row.Cells["IngredientId"].Value);
                string ingredientName = row.Cells["Name"].Value.ToString();
                decimal currentQuantity = Convert.ToDecimal(row.Cells["Quantity"].Value);
                string unit = row.Cells["Unit"].Value?.ToString() ?? "";

                ShowUpdateIngredientQuantityDialog(ingredientId, ingredientName, currentQuantity, unit);
            }
        }

        #endregion

        #region Modal Dialogs

        private void ShowUpdateProductQuantityDialog(int productInventoryId, string productName, int currentQuantity)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Modifier la Quantité";
                dialog.Size = new Size(450, 250);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.BackColor = Color.White;

                // Title Label
                var lblTitle = new Label
                {
                    Text = $"📦 {productName}",
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 73, 94),
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                // Current Quantity Label
                var lblCurrent = new Label
                {
                    Text = $"Quantité actuelle : {currentQuantity}",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 60),
                    AutoSize = true
                };

                // New Quantity Label
                var lblNew = new Label
                {
                    Text = "Nouvelle quantité :",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Location = new Point(20, 100),
                    AutoSize = true
                };

                // NumericUpDown for quantity
                var nudQuantity = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = 10000,
                    Value = currentQuantity,
                    Font = new Font("Segoe UI", 12F),
                    Location = new Point(20, 130),
                    Size = new Size(200, 35)
                };

                // Save Button
                var btnSave = new Button
                {
                    Text = "💾 Enregistrer",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(20, 180),
                    Size = new Size(180, 40),
                    Cursor = Cursors.Hand
                };
                btnSave.FlatAppearance.BorderSize = 0;

                // Cancel Button
                var btnCancel = new Button
                {
                    Text = "Annuler",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    BackColor = Color.FromArgb(149, 165, 166),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(220, 180),
                    Size = new Size(180, 40),
                    Cursor = Cursors.Hand
                };
                btnCancel.FlatAppearance.BorderSize = 0;

                btnSave.Click += (s, ev) =>
                {
                    int newQuantity = (int)nudQuantity.Value;
                    var response = _inventoryService.UpdateProductQuantity(productInventoryId, newQuantity);

                    if (response.IsSuccess)
                    {
                        MessageBox.Show(response.Message, "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dialog.DialogResult = DialogResult.OK;
                        dialog.Close();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                btnCancel.Click += (s, ev) =>
                {
                    dialog.DialogResult = DialogResult.Cancel;
                    dialog.Close();
                };

                dialog.Controls.Add(lblTitle);
                dialog.Controls.Add(lblCurrent);
                dialog.Controls.Add(lblNew);
                dialog.Controls.Add(nudQuantity);
                dialog.Controls.Add(btnSave);
                dialog.Controls.Add(btnCancel);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadProductInventory();
                }
            }
        }

        private void ShowUpdateIngredientQuantityDialog(int ingredientId, string ingredientName, decimal currentQuantity, string unit)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Modifier la Quantité";
                dialog.Size = new Size(450, 250);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.BackColor = Color.White;

                // Title Label
                var lblTitle = new Label
                {
                    Text = $"🧂 {ingredientName}",
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 73, 94),
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                // Current Quantity Label
                var lblCurrent = new Label
                {
                    Text = $"Quantité actuelle : {currentQuantity:N2} {unit}",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 60),
                    AutoSize = true
                };

                // New Quantity Label
                var lblNew = new Label
                {
                    Text = $"Nouvelle quantité ({unit}) :",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Location = new Point(20, 100),
                    AutoSize = true
                };

                // NumericUpDown for quantity
                var nudQuantity = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = 100000,
                    DecimalPlaces = 2,
                    Value = currentQuantity,
                    Font = new Font("Segoe UI", 12F),
                    Location = new Point(20, 130),
                    Size = new Size(200, 35)
                };

                // Save Button
                var btnSave = new Button
                {
                    Text = "💾 Enregistrer",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(20, 180),
                    Size = new Size(180, 40),
                    Cursor = Cursors.Hand
                };
                btnSave.FlatAppearance.BorderSize = 0;

                // Cancel Button
                var btnCancel = new Button
                {
                    Text = "Annuler",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    BackColor = Color.FromArgb(149, 165, 166),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(220, 180),
                    Size = new Size(180, 40),
                    Cursor = Cursors.Hand
                };
                btnCancel.FlatAppearance.BorderSize = 0;

                btnSave.Click += (s, ev) =>
                {
                    decimal newQuantity = nudQuantity.Value;
                    var response = _inventoryService.UpdateIngredientQuantity(ingredientId, newQuantity);

                    if (response.IsSuccess)
                    {
                        MessageBox.Show(response.Message, "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dialog.DialogResult = DialogResult.OK;
                        dialog.Close();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                btnCancel.Click += (s, ev) =>
                {
                    dialog.DialogResult = DialogResult.Cancel;
                    dialog.Close();
                };

                dialog.Controls.Add(lblTitle);
                dialog.Controls.Add(lblCurrent);
                dialog.Controls.Add(lblNew);
                dialog.Controls.Add(nudQuantity);
                dialog.Controls.Add(btnSave);
                dialog.Controls.Add(btnCancel);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadIngredientInventory();
                }
            }
        }

        #endregion
    }
}