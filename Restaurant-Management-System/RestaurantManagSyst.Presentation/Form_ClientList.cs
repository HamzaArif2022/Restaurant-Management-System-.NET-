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
    public partial class Form_ClientList : Form
    {
        private readonly IClientService _clientService;
        private bool _isEditMode = false;
        private int _selectedClientId = 0;

        public Form_ClientList()
        {
            InitializeComponent();
            _clientService = new ClientService();
        }

        private void Form_ClientList_Load(object sender, EventArgs e)
        {
            LoadClients();
            ClearForm();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Style the DataGridView
            dgvClients.AutoGenerateColumns = false;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.ReadOnly = true;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect = false;
            dgvClients.RowHeadersVisible = false;
            dgvClients.BackgroundColor = Color.White;
            dgvClients.BorderStyle = BorderStyle.None;
            dgvClients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvClients.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvClients.DefaultCellStyle.BackColor = Color.White;
            dgvClients.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvClients.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvClients.ColumnHeadersHeight = 40;
            dgvClients.RowTemplate.Height = 35;
            dgvClients.EnableHeadersVisualStyles = false;

            // Clear existing columns
            dgvClients.Columns.Clear();

            // Add columns
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id",
                Width = 60
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nom",
                Name = "Name",
                Width = 200
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Téléphone",
                Name = "Phone",
                Width = 150
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email",
                Width = 200
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "JoinDate",
                HeaderText = "Date d'inscription",
                Name = "JoinDate",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoyaltyPoints",
                HeaderText = "Points",
                Name = "LoyaltyPoints",
                Width = 100
            });
        }

        private void LoadClients()
        {
            var response = _clientService.GetAllClients();

            if (response.IsSuccess)
            {
                var clients = response.Data as List<ClientDTO>;
                dgvClients.DataSource = clients;
                lblTotalClients.Text = $"Total: {clients?.Count ?? 0} client(s)";
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
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditMode = true;
            var selectedClient = dgvClients.SelectedRows[0].DataBoundItem as ClientDTO;

            if (selectedClient != null)
            {
                _selectedClientId = selectedClient.Id;
                txtName.Text = selectedClient.Name;
                txtPhone.Text = selectedClient.Phone;
                txtEmail.Text = selectedClient.Email;
                txtLoyaltyPoints.Text = selectedClient.LoyaltyPoints.ToString();
                CenterFormPanel();
                pnlForm.Visible = true;
                txtName.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedClient = dgvClients.SelectedRows[0].DataBoundItem as ClientDTO;

            if (selectedClient != null)
            {
                var confirmResult = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer le client '{selectedClient.Name}' ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    var response = _clientService.DeleteClient(selectedClient.Id);

                    if (response.IsSuccess)
                    {
                        MessageBox.Show(response.Message, "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClients();
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

            var clientDto = new ClientDTO
            {
                Id = _selectedClientId,
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                LoyaltyPoints = string.IsNullOrWhiteSpace(txtLoyaltyPoints.Text) ? 0 : int.Parse(txtLoyaltyPoints.Text)
            };

            var response = _isEditMode
                ? _clientService.UpdateClient(clientDto)
                : _clientService.AddClient(clientDto);

            if (response.IsSuccess)
            {
                MessageBox.Show(response.Message, "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClients();
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
            var response = _clientService.SearchClients(txtSearch.Text);

            if (response.IsSuccess)
            {
                var clients = response.Data as List<ClientDTO>;
                dgvClients.DataSource = clients;
                lblTotalClients.Text = $"Total: {clients?.Count ?? 0} client(s)";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadClients();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Le nom du client est obligatoire", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtLoyaltyPoints.Text))
            {
                if (!int.TryParse(txtLoyaltyPoints.Text, out int points) || points < 0)
                {
                    MessageBox.Show("Les points de fidélité doivent être un nombre positif", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLoyaltyPoints.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ClearForm()
        {
            _selectedClientId = 0;
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtLoyaltyPoints.Text = "0";
        }

        private void dgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
