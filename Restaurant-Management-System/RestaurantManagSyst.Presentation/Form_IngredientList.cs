using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Enums;
using RestaurantManagSyst.Service.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagSyst.Presentation
{
    public partial class Form_IngredientList : Form
    {
        private readonly IngredientService _ingredientService;
        private List<IngredientDto> _ingredients;
        private IngredientDto _selectedIngredient;

        public Form_IngredientList()
        {
            InitializeComponent();
            _ingredientService = new IngredientService();
        }

        private void Form_IngredientList_Load(object sender, EventArgs e)
        {
            LoadIngredients();
            StyleDataGridView();
            RoundControlCorners();
        }

        private void LoadIngredients()
        {
            var response = _ingredientService.GetAllIngredients();

            if (response.IsSuccess)
            {
                _ingredients = response.Data as List<IngredientDto>;
                DisplayIngredients(_ingredients);
            }
            else
            {
                MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayIngredients(List<IngredientDto> ingredients)
        {
            dgvIngredients.DataSource = null;
            dgvIngredients.DataSource = ingredients;

            if (dgvIngredients.Columns.Count > 0)
            {
                dgvIngredients.Columns["Id"].HeaderText = "ID";
                dgvIngredients.Columns["Id"].Width = 60;
                dgvIngredients.Columns["Name"].HeaderText = "Nom";
                dgvIngredients.Columns["Name"].Width = 200;
                dgvIngredients.Columns["Quantity"].HeaderText = "Quantité";
                dgvIngredients.Columns["Quantity"].Width = 120;
                dgvIngredients.Columns["Quantity"].DefaultCellStyle.Format = "N2";
                dgvIngredients.Columns["Unit"].HeaderText = "Unité";
                dgvIngredients.Columns["Unit"].Width = 120;
            }

            lblTotal.Text = $"Total: {ingredients?.Count ?? 0} ingrédient(s)";
        }

        private void StyleDataGridView()
        {
            dgvIngredients.EnableHeadersVisualStyles = false;
            dgvIngredients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(94, 148, 255);
            dgvIngredients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvIngredients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngredients.ColumnHeadersHeight = 40;

            dgvIngredients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvIngredients.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvIngredients.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvIngredients.RowTemplate.Height = 35;

            dgvIngredients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 247);
            dgvIngredients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvIngredients.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
        }

        private void RoundControlCorners()
        {
            RoundControl(pnlSearch, 10);
            RoundControl(txtSearch, 10);
            RoundButton(btnAdd, 10);
            RoundButton(btnEdit, 10);
            RoundButton(btnDelete, 10);
            RoundButton(btnRefresh, 10);
        }

        private void RoundControl(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        private void RoundButton(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(button.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(button.Width - radius, button.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, button.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                DisplayIngredients(_ingredients);
            }
            else
            {
                var response = _ingredientService.SearchIngredients(searchTerm);

                if (response.IsSuccess)
                {
                    var filteredIngredients = response.Data as List<IngredientDto>;
                    DisplayIngredients(filteredIngredients);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedIngredient == null)
            {
                MessageBox.Show("Veuillez sélectionner un ingrédient à modifier", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowAddEditDialog(_selectedIngredient);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedIngredient == null)
            {
                MessageBox.Show("Veuillez sélectionner un ingrédient à supprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer l'ingrédient '{_selectedIngredient.Name}' ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                var response = _ingredientService.DeleteIngredient(_selectedIngredient.Id);

                if (response.IsSuccess)
                {
                    MessageBox.Show(response.Message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadIngredients();
                    _selectedIngredient = null;
                }
                else
                {
                    MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadIngredients();
            txtSearch.Clear();
        }

        private void dgvIngredients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count > 0)
            {
                _selectedIngredient = dgvIngredients.SelectedRows[0].DataBoundItem as IngredientDto;
            }
        }

        private void dgvIngredients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedIngredient = dgvIngredients.Rows[e.RowIndex].DataBoundItem as IngredientDto;
                ShowAddEditDialog(_selectedIngredient);
            }
        }

        private void ShowAddEditDialog(IngredientDto ingredient)
        {
            // Create modal dialog
            Form dialog = new Form
            {
                Text = ingredient == null ? "Ajouter un ingrédient" : "Modifier l'ingrédient",
                Size = new Size(500, 350),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            // Name
            Label lblName = new Label { Text = "Nom *", Location = new Point(30, 30), Size = new Size(100, 23), Font = new Font("Segoe UI", 10F) };
            TextBox txtName = new TextBox { Location = new Point(150, 30), Size = new Size(300, 30), Font = new Font("Segoe UI", 10F), Text = ingredient?.Name ?? "" };

            // Quantity
            Label lblQuantity = new Label { Text = "Quantité *", Location = new Point(30, 80), Size = new Size(100, 23), Font = new Font("Segoe UI", 10F) };
            NumericUpDown numQuantity = new NumericUpDown
            {
                Location = new Point(150, 80),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 10F),
                DecimalPlaces = 2,
                Maximum = 999999,
                Minimum = 0,
                Value = ingredient?.Quantity ?? 0
            };

            // Unit
            Label lblUnit = new Label { Text = "Unité *", Location = new Point(30, 130), Size = new Size(100, 23), Font = new Font("Segoe UI", 10F) };
            ComboBox cmbUnit = new ComboBox
            {
                Location = new Point(150, 130),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDown
            };
            cmbUnit.Items.AddRange(new string[] { "kg", "g", "L", "ml", "Pièce(s)", "Paquet(s)" });
            cmbUnit.Text = ingredient?.Unit ?? "kg";

            // Buttons
            Button btnSave = new Button
            {
                Text = "Enregistrer",
                Location = new Point(250, 240),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(94, 148, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;

            Button btnCancel = new Button
            {
                Text = "Annuler",
                Location = new Point(380, 240),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            btnSave.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Le nom est requis", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbUnit.Text))
                {
                    MessageBox.Show("L'unité est requise", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ingredientDto = new IngredientDto
                {
                    Id = ingredient?.Id ?? 0,
                    Name = txtName.Text.Trim(),
                    Quantity = numQuantity.Value,
                    Unit = cmbUnit.Text.Trim()
                };

                var response = ingredient == null
                    ? _ingredientService.AddIngredient(ingredientDto)
                    : _ingredientService.UpdateIngredient(ingredientDto);

                if (response.IsSuccess)
                {
                    MessageBox.Show(response.Message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();
                    LoadIngredients();
                }
                else
                {
                    MessageBox.Show(response.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnCancel.Click += (s, ev) =>
            {
                dialog.DialogResult = DialogResult.Cancel;
                dialog.Close();
            };

            dialog.Controls.AddRange(new Control[] { lblName, txtName, lblQuantity, numQuantity, lblUnit, cmbUnit, btnSave, btnCancel });
            dialog.ShowDialog(this);
        }
    }
}
