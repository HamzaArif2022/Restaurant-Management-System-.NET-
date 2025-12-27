using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.IServices;
using RestaurantManagSyst.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagSyst.Presentation
{
    public partial class Form_MenuItemList : Form
    {
        private readonly IMenuItemService _menuItemService;
        private bool _isEditMode = false;
        private int _selectedMenuItemId = 0;

        public Form_MenuItemList()
        {
            InitializeComponent();
            _menuItemService = new MenuItemService();
        }

        private void Form_MenuItemList_Load(object sender, EventArgs e)
        {
            LoadMenuItems();
            ClearForm();
            ConfigureDataGridView();
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Common restaurant menu categories
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[] {
                "Entrées",
                "Plats Principaux",
                "Desserts",
                "Boissons",
                "Salades",
                "Pizzas",
                "Burgers",
                "Pâtes",
                "Grillades",
                "Végétarien",
                "Fruits de Mer",
                "Snacks",
                "Petit-Déjeuner",
                "Spécialités"
            });
        }

        private void ConfigureDataGridView()
        {
            dgvMenuItems.AutoGenerateColumns = false;
            dgvMenuItems.AllowUserToAddRows = false;
            dgvMenuItems.AllowUserToDeleteRows = false;
            dgvMenuItems.ReadOnly = true;
            dgvMenuItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenuItems.MultiSelect = false;
            dgvMenuItems.RowHeadersVisible = false;
            dgvMenuItems.BackgroundColor = Color.White;
            dgvMenuItems.BorderStyle = BorderStyle.None;
            dgvMenuItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMenuItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvMenuItems.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMenuItems.DefaultCellStyle.BackColor = Color.White;
            dgvMenuItems.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvMenuItems.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvMenuItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvMenuItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMenuItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvMenuItems.ColumnHeadersHeight = 40;
            dgvMenuItems.RowTemplate.Height = 35;
            dgvMenuItems.EnableHeadersVisualStyles = false;

            dgvMenuItems.Columns.Clear();

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id",
                Width = 50
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nom",
                Name = "Name",
                Width = 180
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Catégorie",
                Name = "Category",
                Width = 120
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Prix",
                Name = "Price",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BuyingPrice",
                HeaderText = "Prix Achat",
                Name = "BuyingPrice",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProfitMargin",
                HeaderText = "Marge",
                Name = "ProfitMargin",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PreparationTime",
                HeaderText = "Temps (min)",
                Name = "PreparationTime",
                Width = 90
            });

            dgvMenuItems.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsAvailable",
                HeaderText = "Disponible",
                Name = "IsAvailable",
                Width = 90
            });
        }

        private void LoadMenuItems()
        {
            var response = _menuItemService.GetAllMenuItems();

            if (response.IsSuccess)
            {
                var menuItems = response.Data as List<MenuItemDto>;
                dgvMenuItems.DataSource = menuItems;
                lblTotalMenuItems.Text = $"Total: {menuItems?.Count ?? 0} article(s)";
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearForm();
            CenterFormPanel();
            pnlForm.Visible = true;
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMenuItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un article à modifier", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditMode = true;
            var selectedMenuItem = dgvMenuItems.SelectedRows[0].DataBoundItem as MenuItemDto;

            if (selectedMenuItem != null)
            {
                _selectedMenuItemId = selectedMenuItem.Id;
                txtName.Text = selectedMenuItem.Name;
                txtDescription.Text = selectedMenuItem.Description;
                txtPrice.Text = selectedMenuItem.Price.ToString();
                txtBuyingPrice.Text = selectedMenuItem.BuyingPrice?.ToString() ?? "";
                cmbCategory.Text = selectedMenuItem.Category;
                txtPreparationTime.Text = selectedMenuItem.PreparationTime?.ToString() ?? "";
                chkIsAvailable.Checked = selectedMenuItem.IsAvailable;
                txtImage.Text = selectedMenuItem.Image;
                CenterFormPanel();
                pnlForm.Visible = true;
                txtName.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMenuItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un article à supprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedMenuItem = dgvMenuItems.SelectedRows[0].DataBoundItem as MenuItemDto;

            if (selectedMenuItem != null)
            {
                var confirmResult = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer l'article '{selectedMenuItem.Name}' ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    var response = _menuItemService.DeleteMenuItem(selectedMenuItem.Id);

                    if (response.IsSuccess)
                    {
                        MessageBox.Show(response.Message, "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMenuItems();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnToggleAvailability_Click(object sender, EventArgs e)
        {
            if (dgvMenuItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un article", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedMenuItem = dgvMenuItems.SelectedRows[0].DataBoundItem as MenuItemDto;

            if (selectedMenuItem != null)
            {
                var response = _menuItemService.ToggleAvailability(selectedMenuItem.Id);

                if (response.IsSuccess)
                {
                    MessageBox.Show(response.Message, "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenuItems();
                }
                else
                {
                    MessageBox.Show(response.Message, "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var menuItemDto = new MenuItemDto
            {
                Id = _selectedMenuItemId,
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text),
                BuyingPrice = string.IsNullOrWhiteSpace(txtBuyingPrice.Text) ? (decimal?)null : decimal.Parse(txtBuyingPrice.Text),
                Category = cmbCategory.Text.Trim(),
                PreparationTime = string.IsNullOrWhiteSpace(txtPreparationTime.Text) ? (int?)null : int.Parse(txtPreparationTime.Text),
                IsAvailable = chkIsAvailable.Checked,
                Image = txtImage.Text.Trim()
            };

            var response = _isEditMode
                ? _menuItemService.UpdateMenuItem(menuItemDto)
                : _menuItemService.AddMenuItem(menuItemDto);

            if (response.IsSuccess)
            {
                MessageBox.Show(response.Message, "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenuItems();
                pnlForm.Visible = false;
                ClearForm();
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            ClearForm();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var response = _menuItemService.SearchMenuItems(txtSearch.Text);

            if (response.IsSuccess)
            {
                var menuItems = response.Data as List<MenuItemDto>;
                dgvMenuItems.DataSource = menuItems;
                lblTotalMenuItems.Text = $"Total: {menuItems?.Count ?? 0} article(s)";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadMenuItems();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Le nom de l'article est obligatoire", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Le prix est obligatoire", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Le prix doit être un nombre supérieur à zéro", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtBuyingPrice.Text))
            {
                if (!decimal.TryParse(txtBuyingPrice.Text, out decimal buyingPrice) || buyingPrice < 0)
                {
                    MessageBox.Show("Le prix d'achat doit être un nombre positif", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuyingPrice.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtPreparationTime.Text))
            {
                if (!int.TryParse(txtPreparationTime.Text, out int prepTime) || prepTime < 0)
                {
                    MessageBox.Show("Le temps de préparation doit être un nombre positif", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPreparationTime.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ClearForm()
        {
            _selectedMenuItemId = 0;
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtBuyingPrice.Clear();
            cmbCategory.SelectedIndex = -1;
            txtPreparationTime.Clear();
            chkIsAvailable.Checked = true;
            txtImage.Clear();
        }

        private void dgvMenuItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void CenterFormPanel()
        {
            pnlForm.Left = (this.ClientSize.Width - pnlForm.Width) / 2;
            pnlForm.Top = (this.ClientSize.Height - pnlForm.Height) / 2;
        }
    }
}
