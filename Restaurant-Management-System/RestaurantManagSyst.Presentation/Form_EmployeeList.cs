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
    public partial class Form_EmployeeList : Form
    {
        private readonly IEmployeeService _employeeService;
        private bool _isEditMode = false;
        private int _selectedEmployeeId = 0;

        public Form_EmployeeList()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
        }

        private void Form_EmployeeList_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            ClearForm();
            ConfigureDataGridView();
            LoadRoles();
        }

        private void LoadRoles()
        {
            // Common restaurant roles
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] {
                "Manager",
                "Chef",
                "Sous Chef",
                "Serveur",
                "Barman",
                "Caissier",
                "Cuisinier",
                "Aide-Cuisinier",
                "Plongeur",
                "Hôte d'accueil"
            });
        }

        private void ConfigureDataGridView()
        {
            // Style the DataGridView
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.MultiSelect = false;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvEmployees.DefaultCellStyle.BackColor = Color.White;
            dgvEmployees.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvEmployees.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvEmployees.ColumnHeadersHeight = 40;
            dgvEmployees.RowTemplate.Height = 35;
            dgvEmployees.EnableHeadersVisualStyles = false;

            // Clear existing columns
            dgvEmployees.Columns.Clear();

            // Add columns
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id",
                Width = 60
            });

            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nom",
                Name = "Name",
                Width = 180
            });

            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Rôle",
                Name = "Role",
                Width = 150
            });

            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Téléphone",
                Name = "Phone",
                Width = 130
            });

            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email",
                Width = 200
            });

            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HireDate",
                HeaderText = "Date d'embauche",
                Name = "HireDate",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        private void LoadEmployees()
        {
            var response = _employeeService.GetAllEmployees();

            if (response.IsSuccess)
            {
                var employees = response.Data as List<EmployeeDto>;
                dgvEmployees.DataSource = employees;
                lblTotalEmployees.Text = $"Total: {employees?.Count ?? 0} employé(s)";
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
            lblPasswordNote.Text = "* Mot de passe (obligatoire pour nouvel employé)";
            txtPassword.Enabled = true;
            CenterFormPanel();
            pnlForm.Visible = true;
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un employé à modifier", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditMode = true;
            var selectedEmployee = dgvEmployees.SelectedRows[0].DataBoundItem as EmployeeDto;

            if (selectedEmployee != null)
            {
                _selectedEmployeeId = selectedEmployee.Id;
                txtName.Text = selectedEmployee.Name;
                cmbRole.Text = selectedEmployee.Role;
                txtPhone.Text = selectedEmployee.Phone;
                txtEmail.Text = selectedEmployee.Email;
                dtpHireDate.Value = selectedEmployee.HireDate ?? DateTime.Now;
                txtPassword.Text = "";
                lblPasswordNote.Text = "Mot de passe (laisser vide pour ne pas changer)";
                txtPassword.Enabled = true;
                CenterFormPanel();
                pnlForm.Visible = true;
                txtName.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un employé à supprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedEmployee = dgvEmployees.SelectedRows[0].DataBoundItem as EmployeeDto;

            if (selectedEmployee != null)
            {
                var confirmResult = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer l'employé '{selectedEmployee.Name}' ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    var response = _employeeService.DeleteEmployee(selectedEmployee.Id);

                    if (response.IsSuccess)
                    {
                        MessageBox.Show(response.Message, "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var employeeDto = new EmployeeDto
            {
                Id = _selectedEmployeeId,
                Name = txtName.Text.Trim(),
                Role = cmbRole.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                HireDate = dtpHireDate.Value.Date,
                Password = txtPassword.Text.Trim()
            };

            var response = _isEditMode
                ? _employeeService.UpdateEmployee(employeeDto)
                : _employeeService.AddEmployee(employeeDto);

            if (response.IsSuccess)
            {
                MessageBox.Show(response.Message, "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees();
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
            var response = _employeeService.SearchEmployees(txtSearch.Text);

            if (response.IsSuccess)
            {
                var employees = response.Data as List<EmployeeDto>;
                dgvEmployees.DataSource = employees;
                lblTotalEmployees.Text = $"Total: {employees?.Count ?? 0} employé(s)";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadEmployees();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Le nom de l'employé est obligatoire", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("Le rôle de l'employé est obligatoire", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            // Password required only for new employees
            if (!_isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Le mot de passe est obligatoire pour un nouvel employé", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // If password is provided, check minimum length
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 6 caractères", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            _selectedEmployeeId = 0;
            txtName.Clear();
            cmbRole.SelectedIndex = -1;
            txtPhone.Clear();
            txtEmail.Clear();
            dtpHireDate.Value = DateTime.Now;
            txtPassword.Clear();
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void CenterFormPanel()
        {
            // Center the form panel on the screen
            pnlForm.Left = (this.ClientSize.Width - pnlForm.Width) / 2;
            pnlForm.Top = (this.ClientSize.Height - pnlForm.Height) / 2;
        }
    }
}
