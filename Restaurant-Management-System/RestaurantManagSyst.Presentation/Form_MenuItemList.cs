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
    public partial class Form_MenuItemList : Form
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IIngredientService _ingredientService;
        private readonly IMenuItemIngredientService _menuItemIngredientService;

        private bool _isEditMode = false;
        private int _selectedMenuItemId = 0;
        private List<MenuItemIngredientDto> _linkedIngredients;

        public Form_MenuItemList()
        {
            InitializeComponent();
            _menuItemService = new MenuItemService();
            _ingredientService = new IngredientService();
            _menuItemIngredientService = new MenuItemIngredientService();
            _linkedIngredients = new List<MenuItemIngredientDto>();
        }

        private void Form_MenuItemList_Load(object sender, EventArgs e)
        {
            LoadMenuItems();
            ClearForm();
            ConfigureDataGridView();
            ConfigureIngredientsDataGridView();
            LoadCategories();
            LoadAllIngredients();
        }

        #region Configuration Methods

        private void LoadCategories()
        {
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

        private void ConfigureIngredientsDataGridView()
        {
            // Configure dgvIngredients (Available Ingredients)
            dgvIngredients.AutoGenerateColumns = false;
            dgvIngredients.AllowUserToAddRows = false;
            dgvIngredients.ReadOnly = true;
            dgvIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngredients.MultiSelect = false;
            dgvIngredients.RowHeadersVisible = false;
            dgvIngredients.BackgroundColor = Color.White;
            dgvIngredients.BorderStyle = BorderStyle.FixedSingle;
            dgvIngredients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvIngredients.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvIngredients.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvIngredients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvIngredients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvIngredients.ColumnHeadersHeight = 30;
            dgvIngredients.RowTemplate.Height = 28;
            dgvIngredients.EnableHeadersVisualStyles = false;

            dgvIngredients.Columns.Clear();
            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 40
            });
            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nom",
                Width = 180
            });
            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unit",
                HeaderText = "Unité",
                Width = 80
            });

            // Configure dgvLinkedIngredients
            dgvLinkedIngredients.AutoGenerateColumns = false;
            dgvLinkedIngredients.AllowUserToAddRows = false;
            dgvLinkedIngredients.ReadOnly = true;
            dgvLinkedIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLinkedIngredients.MultiSelect = false;
            dgvLinkedIngredients.RowHeadersVisible = false;
            dgvLinkedIngredients.BackgroundColor = Color.White;
            dgvLinkedIngredients.BorderStyle = BorderStyle.FixedSingle;
            dgvLinkedIngredients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 76, 60);
            dgvLinkedIngredients.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvLinkedIngredients.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvLinkedIngredients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
            dgvLinkedIngredients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLinkedIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvLinkedIngredients.ColumnHeadersHeight = 30;
            dgvLinkedIngredients.RowTemplate.Height = 28;
            dgvLinkedIngredients.EnableHeadersVisualStyles = false;

            dgvLinkedIngredients.Columns.Clear();
            dgvLinkedIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IngredientName",
                HeaderText = "Ingrédient",
                Width = 150
            });
            dgvLinkedIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "QuantityRequired",
                HeaderText = "Quantité",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
            dgvLinkedIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unit",
                HeaderText = "Unité",
                Width = 70
            });
        }

        #endregion

        #region Data Loading Methods

        private void LoadAllIngredients()
        {
            var response = _ingredientService.GetAllIngredients();
            if (response.IsSuccess)
            {
                var ingredients = response.Data as List<IngredientDto>;
                dgvIngredients.DataSource = ingredients;
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLinkedIngredients(int menuItemId)
        {
            var response = _menuItemIngredientService.GetIngredientsByMenuItemId(menuItemId);
            if (response.IsSuccess)
            {
                _linkedIngredients = (response.Data as List<MenuItemIngredientDto>) ?? new List<MenuItemIngredientDto>();
                RefreshLinkedIngredientsGrid();
            }
            else
            {
                _linkedIngredients = new List<MenuItemIngredientDto>();
                dgvLinkedIngredients.DataSource = null;
            }
        }

        private void RefreshLinkedIngredientsGrid()
        {
            dgvLinkedIngredients.DataSource = null;
            dgvLinkedIngredients.DataSource = _linkedIngredients;
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

        #endregion

        #region Button Click Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            _selectedMenuItemId = 0;
            ClearForm();
            _linkedIngredients.Clear();
            dgvLinkedIngredients.DataSource = null;
            lblFormTitle.Text = "🍔 Nouvel Article du Menu";
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
                txtPrice.Text = selectedMenuItem.Price.ToString("F2");
                txtBuyingPrice.Text = selectedMenuItem.BuyingPrice?.ToString("F2") ?? "";
                cmbCategory.Text = selectedMenuItem.Category;
                txtPreparationTime.Text = selectedMenuItem.PreparationTime?.ToString() ?? "";
                chkIsAvailable.Checked = selectedMenuItem.IsAvailable;
                txtImage.Text = selectedMenuItem.Image;

                // Load linked ingredients for editing
                LoadLinkedIngredients(_selectedMenuItemId);

                lblFormTitle.Text = $"✏️ Modifier: {selectedMenuItem.Name}";
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
                    $"Êtes-vous sûr de vouloir supprimer l'article '{selectedMenuItem.Name}' ?\n\nTous les ingrédients liés seront également supprimés.",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Delete linked ingredients first
                    _menuItemIngredientService.DeleteByMenuItemId(selectedMenuItem.Id);

                    // Then delete menu item
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

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un ingrédient", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedIngredient = dgvIngredients.SelectedRows[0].DataBoundItem as IngredientDto;

            if (selectedIngredient != null)
            {
                // Check if ingredient already linked
                if (_linkedIngredients.Any(li => li.IngredientId == selectedIngredient.Id))
                {
                    MessageBox.Show("Cet ingrédient est déjà lié à cet article", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Add to temporary list
                var menuItemIngredient = new MenuItemIngredientDto
                {
                    MenuItemId = _selectedMenuItemId,
                    IngredientId = selectedIngredient.Id,
                    IngredientName = selectedIngredient.Name,
                    QuantityRequired = nudQuantityRequired.Value,
                    Unit = selectedIngredient.Unit
                };

                _linkedIngredients.Add(menuItemIngredient);

                // Refresh grid
                RefreshLinkedIngredientsGrid();

                MessageBox.Show($"Ingrédient '{selectedIngredient.Name}' ajouté avec succès!", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset quantity to 1
                nudQuantityRequired.Value = 1;
            }
        }

        private void btnRemoveIngredient_Click(object sender, EventArgs e)
        {
            if (dgvLinkedIngredients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un ingrédient à retirer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedLinkedIngredient = dgvLinkedIngredients.SelectedRows[0].DataBoundItem as MenuItemIngredientDto;

            if (selectedLinkedIngredient != null)
            {
                var confirmResult = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir retirer '{selectedLinkedIngredient.IngredientName}' ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    _linkedIngredients.Remove(selectedLinkedIngredient);

                    // Refresh grid
                    RefreshLinkedIngredientsGrid();

                    MessageBox.Show("Ingrédient retiré avec succès!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // Save MenuItem first
            var response = _isEditMode
                ? _menuItemService.UpdateMenuItem(menuItemDto)
                : _menuItemService.AddMenuItem(menuItemDto);

            if (response.IsSuccess)
            {
                var savedMenuItem = response.Data as MenuItemDto;
                int menuItemId = savedMenuItem?.Id ?? _selectedMenuItemId;

                // Save linked ingredients
                // If editing, delete existing links first
                if (_isEditMode)
                {
                    _menuItemIngredientService.DeleteByMenuItemId(menuItemId);
                }

                // Add new links
                if (_linkedIngredients.Any())
                {
                    foreach (var linkedIngredient in _linkedIngredients)
                    {
                        linkedIngredient.MenuItemId = menuItemId;
                        _menuItemIngredientService.AddMenuItemIngredient(linkedIngredient);
                    }
                }

                MessageBox.Show(
                    _isEditMode ? "Article mis à jour avec succès!" : "Article créé avec succès!",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

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
            var confirmResult = MessageBox.Show(
                "Êtes-vous sûr de vouloir annuler ? Les modifications non enregistrées seront perdues.",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                pnlForm.Visible = false;
                ClearForm();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadMenuItems();
            LoadAllIngredients();
            MessageBox.Show("Données actualisées avec succès!", "Actualisation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Search and Filter

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

        #endregion

        #region Validation Methods

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

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Veuillez sélectionner une catégorie", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Utility Methods

        private void ClearForm()
        {
            _selectedMenuItemId = 0;
            _isEditMode = false;
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtBuyingPrice.Clear();
            cmbCategory.SelectedIndex = -1;
            txtPreparationTime.Clear();
            chkIsAvailable.Checked = true;
            txtImage.Clear();
            nudQuantityRequired.Value = 1;
            _linkedIngredients.Clear();
            dgvLinkedIngredients.DataSource = null;
            lblFormTitle.Text = "🍔 Article du Menu";
        }

        private void CenterFormPanel()
        {
            pnlForm.Left = (this.ClientSize.Width - pnlForm.Width) / 2;
            pnlForm.Top = (this.ClientSize.Height - pnlForm.Height) / 2;
        }

        #endregion

        #region DataGridView Events

        private void dgvMenuItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        #endregion
    }
}