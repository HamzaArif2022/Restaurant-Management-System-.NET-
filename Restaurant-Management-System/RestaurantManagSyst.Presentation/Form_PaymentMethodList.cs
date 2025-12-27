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
    public partial class Form_PaymentMethodList : Form
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private bool _isEditMode = false;
        private int _selectedPaymentMethodId = 0;

        public Form_PaymentMethodList()
        {
            InitializeComponent();
            _paymentMethodService = new PaymentMethodService();
        }

        private void Form_PaymentMethodList_Load(object sender, EventArgs e)
        {
            LoadPaymentMethods();
            ClearForm();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Style the DataGridView
            dgvPaymentMethods.AutoGenerateColumns = false;
            dgvPaymentMethods.AllowUserToAddRows = false;
            dgvPaymentMethods.AllowUserToDeleteRows = false;
            dgvPaymentMethods.ReadOnly = true;
            dgvPaymentMethods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaymentMethods.MultiSelect = false;
            dgvPaymentMethods.RowHeadersVisible = false;
            dgvPaymentMethods.BackgroundColor = Color.White;
            dgvPaymentMethods.BorderStyle = BorderStyle.None;
            dgvPaymentMethods.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPaymentMethods.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255);
            dgvPaymentMethods.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPaymentMethods.DefaultCellStyle.BackColor = Color.White;
            dgvPaymentMethods.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvPaymentMethods.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvPaymentMethods.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvPaymentMethods.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPaymentMethods.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvPaymentMethods.ColumnHeadersHeight = 40;
            dgvPaymentMethods.RowTemplate.Height = 35;
            dgvPaymentMethods.EnableHeadersVisualStyles = false;

            // Clear existing columns
            dgvPaymentMethods.Columns.Clear();

            // Add columns
            dgvPaymentMethods.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id",
                Width = 80
            });

            dgvPaymentMethods.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Label",
                HeaderText = "Méthode de Paiement",
                Name = "Label",
                Width = 400
            });

            dgvPaymentMethods.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "Active",
                Name = "IsActive",
                Width = 100
            });
        }

        private void LoadPaymentMethods()
        {
            var response = _paymentMethodService.GetAllPaymentMethods();

            if (response.IsSuccess)
            {
                var paymentMethods = response.Data as List<PaymentMethodDto>;
                dgvPaymentMethods.DataSource = paymentMethods;
                lblTotalPaymentMethods.Text = $"Total: {paymentMethods?.Count ?? 0} méthode(s)";
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
            txtLabel.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPaymentMethods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une méthode de paiement à modifier", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditMode = true;
            var selectedPaymentMethod = dgvPaymentMethods.SelectedRows[0].DataBoundItem as PaymentMethodDto;

            if (selectedPaymentMethod != null)
            {
                _selectedPaymentMethodId = selectedPaymentMethod.Id;
                txtLabel.Text = selectedPaymentMethod.Label;
                chkIsActive.Checked = selectedPaymentMethod.IsActive;
                CenterFormPanel();
                pnlForm.Visible = true;
                txtLabel.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPaymentMethods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une méthode de paiement à supprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedPaymentMethod = dgvPaymentMethods.SelectedRows[0].DataBoundItem as PaymentMethodDto;

            if (selectedPaymentMethod != null)
            {
                var confirmResult = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer la méthode de paiement '{selectedPaymentMethod.Label}' ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    var response = _paymentMethodService.DeletePaymentMethod(selectedPaymentMethod.Id);

                    if (response.IsSuccess)
                    {
                        MessageBox.Show(response.Message, "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPaymentMethods();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvPaymentMethods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une méthode de paiement", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedPaymentMethod = dgvPaymentMethods.SelectedRows[0].DataBoundItem as PaymentMethodDto;

            if (selectedPaymentMethod != null)
            {
                var response = _paymentMethodService.ToggleActiveStatus(selectedPaymentMethod.Id);

                if (response.IsSuccess)
                {
                    MessageBox.Show(response.Message, "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPaymentMethods();
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

            var paymentMethodDto = new PaymentMethodDto
            {
                Id = _selectedPaymentMethodId,
                Label = txtLabel.Text.Trim(),
                IsActive = chkIsActive.Checked
            };

            var response = _isEditMode
                ? _paymentMethodService.UpdatePaymentMethod(paymentMethodDto)
                : _paymentMethodService.AddPaymentMethod(paymentMethodDto);

            if (response.IsSuccess)
            {
                MessageBox.Show(response.Message, "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPaymentMethods();
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
            var response = _paymentMethodService.SearchPaymentMethods(txtSearch.Text);

            if (response.IsSuccess)
            {
                var paymentMethods = response.Data as List<PaymentMethodDto>;
                dgvPaymentMethods.DataSource = paymentMethods;
                lblTotalPaymentMethods.Text = $"Total: {paymentMethods?.Count ?? 0} méthode(s)";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadPaymentMethods();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLabel.Text))
            {
                MessageBox.Show("Le nom de la méthode de paiement est obligatoire", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLabel.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            _selectedPaymentMethodId = 0;
            txtLabel.Clear();
            chkIsActive.Checked = true;
        }

        private void dgvPaymentMethods_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
