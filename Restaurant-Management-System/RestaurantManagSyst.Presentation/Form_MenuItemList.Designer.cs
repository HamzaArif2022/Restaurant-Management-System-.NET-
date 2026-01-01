namespace RestaurantManagSyst.Presentation
{
    partial class Form_MenuItemList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTotalMenuItems = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnToggleAvailability = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvMenuItems = new System.Windows.Forms.DataGridView();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlIngredients = new System.Windows.Forms.Panel();
            this.btnRemoveIngredient = new System.Windows.Forms.Button();
            this.dgvLinkedIngredients = new System.Windows.Forms.DataGridView();
            this.lblLinkedIngredients = new System.Windows.Forms.Label();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.nudQuantityRequired = new System.Windows.Forms.NumericUpDown();
            this.lblQuantityRequired = new System.Windows.Forms.Label();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.lblIngredientsTitle = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.chkIsAvailable = new System.Windows.Forms.CheckBox();
            this.txtPreparationTime = new System.Windows.Forms.TextBox();
            this.lblPreparationTime = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtBuyingPrice = new System.Windows.Forms.TextBox();
            this.lblBuyingPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.pnlIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinkedIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTotalMenuItems);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnToggleAvailability);
            this.pnlTop.Controls.Add(this.btnDelete);
            this.pnlTop.Controls.Add(this.btnEdit);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(27, 25, 27, 12);
            this.pnlTop.Size = new System.Drawing.Size(1533, 98);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTotalMenuItems
            // 
            this.lblTotalMenuItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMenuItems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalMenuItems.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalMenuItems.Location = new System.Drawing.Point(1266, 63);
            this.lblTotalMenuItems.Name = "lblTotalMenuItems";
            this.lblTotalMenuItems.Size = new System.Drawing.Size(240, 28);
            this.lblTotalMenuItems.TabIndex = 7;
            this.lblTotalMenuItems.Text = "Total: 0 article(s)";
            this.lblTotalMenuItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1176, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 43);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "🔄";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnToggleAvailability
            // 
            this.btnToggleAvailability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleAvailability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnToggleAvailability.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleAvailability.FlatAppearance.BorderSize = 0;
            this.btnToggleAvailability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleAvailability.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleAvailability.ForeColor = System.Drawing.Color.White;
            this.btnToggleAvailability.Location = new System.Drawing.Point(912, 11);
            this.btnToggleAvailability.Name = "btnToggleAvailability";
            this.btnToggleAvailability.Size = new System.Drawing.Size(80, 43);
            this.btnToggleAvailability.TabIndex = 5;
            this.btnToggleAvailability.Text = "🔀";
            this.btnToggleAvailability.UseVisualStyleBackColor = false;
            this.btnToggleAvailability.Click += new System.EventHandler(this.btnToggleAvailability_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1088, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 43);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "🗑️";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(1000, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 43);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "✏️";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1262, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(240, 43);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "➕ Ajouter Article";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(31, 53);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(532, 32);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSearch.Location = new System.Drawing.Point(27, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(354, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "🔍 Rechercher (Nom, Description, Catégorie)";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.dgvMenuItems);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 98);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlMain.Size = new System.Drawing.Size(1533, 825);
            this.pnlMain.TabIndex = 1;
            // 
            // dgvMenuItems
            // 
            this.dgvMenuItems.AllowUserToAddRows = false;
            this.dgvMenuItems.AllowUserToDeleteRows = false;
            this.dgvMenuItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenuItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenuItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMenuItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenuItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMenuItems.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMenuItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenuItems.EnableHeadersVisualStyles = false;
            this.dgvMenuItems.Location = new System.Drawing.Point(27, 25);
            this.dgvMenuItems.MultiSelect = false;
            this.dgvMenuItems.Name = "dgvMenuItems";
            this.dgvMenuItems.ReadOnly = true;
            this.dgvMenuItems.RowHeadersVisible = false;
            this.dgvMenuItems.RowHeadersWidth = 51;
            this.dgvMenuItems.RowTemplate.Height = 35;
            this.dgvMenuItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuItems.Size = new System.Drawing.Size(1479, 775);
            this.dgvMenuItems.TabIndex = 0;
            this.dgvMenuItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuItems_CellDoubleClick);
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.pnlIngredients);
            this.pnlForm.Controls.Add(this.txtImage);
            this.pnlForm.Controls.Add(this.lblImage);
            this.pnlForm.Controls.Add(this.chkIsAvailable);
            this.pnlForm.Controls.Add(this.txtPreparationTime);
            this.pnlForm.Controls.Add(this.lblPreparationTime);
            this.pnlForm.Controls.Add(this.cmbCategory);
            this.pnlForm.Controls.Add(this.lblCategory);
            this.pnlForm.Controls.Add(this.txtBuyingPrice);
            this.pnlForm.Controls.Add(this.lblBuyingPrice);
            this.pnlForm.Controls.Add(this.txtPrice);
            this.pnlForm.Controls.Add(this.lblPrice);
            this.pnlForm.Controls.Add(this.txtDescription);
            this.pnlForm.Controls.Add(this.lblDescription);
            this.pnlForm.Controls.Add(this.btnCancel);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Controls.Add(this.lblFormTitle);
            this.pnlForm.Location = new System.Drawing.Point(100, 30);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1300, 850);
            this.pnlForm.TabIndex = 2;
            this.pnlForm.Visible = false;
            // 
            // pnlIngredients
            // 
            this.pnlIngredients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlIngredients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIngredients.Controls.Add(this.btnRemoveIngredient);
            this.pnlIngredients.Controls.Add(this.dgvLinkedIngredients);
            this.pnlIngredients.Controls.Add(this.lblLinkedIngredients);
            this.pnlIngredients.Controls.Add(this.btnAddIngredient);
            this.pnlIngredients.Controls.Add(this.nudQuantityRequired);
            this.pnlIngredients.Controls.Add(this.lblQuantityRequired);
            this.pnlIngredients.Controls.Add(this.dgvIngredients);
            this.pnlIngredients.Controls.Add(this.lblIngredientsTitle);
            this.pnlIngredients.Location = new System.Drawing.Point(880, 160);
            this.pnlIngredients.Name = "pnlIngredients";
            this.pnlIngredients.Size = new System.Drawing.Size(400, 630);
            this.pnlIngredients.TabIndex = 18;
            // 
            // btnRemoveIngredient
            // 
            this.btnRemoveIngredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveIngredient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveIngredient.FlatAppearance.BorderSize = 0;
            this.btnRemoveIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveIngredient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveIngredient.ForeColor = System.Drawing.Color.White;
            this.btnRemoveIngredient.Location = new System.Drawing.Point(15, 580);
            this.btnRemoveIngredient.Name = "btnRemoveIngredient";
            this.btnRemoveIngredient.Size = new System.Drawing.Size(370, 35);
            this.btnRemoveIngredient.TabIndex = 7;
            this.btnRemoveIngredient.Text = "🗑️ Retirer l\'ingrédient sélectionné";
            this.btnRemoveIngredient.UseVisualStyleBackColor = false;
            this.btnRemoveIngredient.Click += new System.EventHandler(this.btnRemoveIngredient_Click);
            // 
            // dgvLinkedIngredients
            // 
            this.dgvLinkedIngredients.AllowUserToAddRows = false;
            this.dgvLinkedIngredients.AllowUserToDeleteRows = false;
            this.dgvLinkedIngredients.BackgroundColor = System.Drawing.Color.White;
            this.dgvLinkedIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLinkedIngredients.Location = new System.Drawing.Point(15, 360);
            this.dgvLinkedIngredients.Name = "dgvLinkedIngredients";
            this.dgvLinkedIngredients.ReadOnly = true;
            this.dgvLinkedIngredients.RowHeadersVisible = false;
            this.dgvLinkedIngredients.RowHeadersWidth = 51;
            this.dgvLinkedIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinkedIngredients.Size = new System.Drawing.Size(370, 210);
            this.dgvLinkedIngredients.TabIndex = 6;
            // 
            // lblLinkedIngredients
            // 
            this.lblLinkedIngredients.AutoSize = true;
            this.lblLinkedIngredients.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLinkedIngredients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblLinkedIngredients.Location = new System.Drawing.Point(15, 330);
            this.lblLinkedIngredients.Name = "lblLinkedIngredients";
            this.lblLinkedIngredients.Size = new System.Drawing.Size(174, 25);
            this.lblLinkedIngredients.TabIndex = 5;
            this.lblLinkedIngredients.Text = "✅ Ingrédients liés";
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddIngredient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddIngredient.FlatAppearance.BorderSize = 0;
            this.btnAddIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIngredient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddIngredient.ForeColor = System.Drawing.Color.White;
            this.btnAddIngredient.Location = new System.Drawing.Point(210, 265);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(175, 35);
            this.btnAddIngredient.TabIndex = 4;
            this.btnAddIngredient.Text = "➕ Ajouter";
            this.btnAddIngredient.UseVisualStyleBackColor = false;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // nudQuantityRequired
            // 
            this.nudQuantityRequired.DecimalPlaces = 2;
            this.nudQuantityRequired.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudQuantityRequired.Location = new System.Drawing.Point(15, 265);
            this.nudQuantityRequired.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudQuantityRequired.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudQuantityRequired.Name = "nudQuantityRequired";
            this.nudQuantityRequired.Size = new System.Drawing.Size(180, 30);
            this.nudQuantityRequired.TabIndex = 3;
            this.nudQuantityRequired.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantityRequired
            // 
            this.lblQuantityRequired.AutoSize = true;
            this.lblQuantityRequired.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuantityRequired.Location = new System.Drawing.Point(15, 240);
            this.lblQuantityRequired.Name = "lblQuantityRequired";
            this.lblQuantityRequired.Size = new System.Drawing.Size(133, 20);
            this.lblQuantityRequired.TabIndex = 2;
            this.lblQuantityRequired.Text = "Quantité requise :";
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AllowUserToAddRows = false;
            this.dgvIngredients.AllowUserToDeleteRows = false;
            this.dgvIngredients.BackgroundColor = System.Drawing.Color.White;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Location = new System.Drawing.Point(15, 50);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.ReadOnly = true;
            this.dgvIngredients.RowHeadersVisible = false;
            this.dgvIngredients.RowHeadersWidth = 51;
            this.dgvIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredients.Size = new System.Drawing.Size(370, 180);
            this.dgvIngredients.TabIndex = 1;
            // 
            // lblIngredientsTitle
            // 
            this.lblIngredientsTitle.AutoSize = true;
            this.lblIngredientsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblIngredientsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblIngredientsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblIngredientsTitle.Name = "lblIngredientsTitle";
            this.lblIngredientsTitle.Size = new System.Drawing.Size(266, 28);
            this.lblIngredientsTitle.TabIndex = 0;
            this.lblIngredientsTitle.Text = "🧂 Ingrédients disponibles";
            // 
            // txtImage
            // 
            this.txtImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImage.Location = new System.Drawing.Point(40, 628);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(785, 30);
            this.txtImage.TabIndex = 17;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblImage.Location = new System.Drawing.Point(40, 597);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(157, 23);
            this.lblImage.TabIndex = 16;
            this.lblImage.Text = "URL Image (opt.) :";
            // 
            // chkIsAvailable
            // 
            this.chkIsAvailable.AutoSize = true;
            this.chkIsAvailable.Checked = true;
            this.chkIsAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsAvailable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIsAvailable.Location = new System.Drawing.Point(47, 671);
            this.chkIsAvailable.Name = "chkIsAvailable";
            this.chkIsAvailable.Size = new System.Drawing.Size(112, 27);
            this.chkIsAvailable.TabIndex = 15;
            this.chkIsAvailable.Text = "Disponible";
            this.chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // txtPreparationTime
            // 
            this.txtPreparationTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPreparationTime.Location = new System.Drawing.Point(460, 548);
            this.txtPreparationTime.Name = "txtPreparationTime";
            this.txtPreparationTime.Size = new System.Drawing.Size(365, 30);
            this.txtPreparationTime.TabIndex = 14;
            // 
            // lblPreparationTime
            // 
            this.lblPreparationTime.AutoSize = true;
            this.lblPreparationTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreparationTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPreparationTime.Location = new System.Drawing.Point(460, 517);
            this.lblPreparationTime.Name = "lblPreparationTime";
            this.lblPreparationTime.Size = new System.Drawing.Size(219, 23);
            this.lblPreparationTime.TabIndex = 13;
            this.lblPreparationTime.Text = "Temps préparation (min) :";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(40, 548);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(365, 31);
            this.cmbCategory.TabIndex = 12;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCategory.Location = new System.Drawing.Point(40, 517);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(98, 23);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Catégorie :";
            // 
            // txtBuyingPrice
            // 
            this.txtBuyingPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuyingPrice.Location = new System.Drawing.Point(460, 462);
            this.txtBuyingPrice.Name = "txtBuyingPrice";
            this.txtBuyingPrice.Size = new System.Drawing.Size(365, 30);
            this.txtBuyingPrice.TabIndex = 10;
            // 
            // lblBuyingPrice
            // 
            this.lblBuyingPrice.AutoSize = true;
            this.lblBuyingPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBuyingPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBuyingPrice.Location = new System.Drawing.Point(460, 431);
            this.lblBuyingPrice.Name = "lblBuyingPrice";
            this.lblBuyingPrice.Size = new System.Drawing.Size(165, 23);
            this.lblBuyingPrice.TabIndex = 9;
            this.lblBuyingPrice.Text = "Prix d\'achat (opt.) :";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.Location = new System.Drawing.Point(40, 462);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(365, 30);
            this.txtPrice.TabIndex = 8;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrice.Location = new System.Drawing.Point(40, 431);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(138, 23);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Prix de vente * :";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(40, 277);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(785, 122);
            this.txtDescription.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescription.Location = new System.Drawing.Point(40, 246);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(112, 23);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description :";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(460, 720);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(367, 55);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(40, 720);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(367, 55);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "💾 Enregistrer";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(40, 191);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(785, 30);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblName.Location = new System.Drawing.Point(40, 160);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(162, 23);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nom de l\'article * :";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(1298, 123);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "🍔 Article du Menu";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_MenuItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1533, 923);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_MenuItemList";
            this.Text = "Gestion du Menu";
            this.Load += new System.EventHandler(this.Form_MenuItemList_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlIngredients.ResumeLayout(false);
            this.pnlIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinkedIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnToggleAvailability;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTotalMenuItems;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvMenuItems;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtBuyingPrice;
        private System.Windows.Forms.Label lblBuyingPrice;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtPreparationTime;
        private System.Windows.Forms.Label lblPreparationTime;
        private System.Windows.Forms.CheckBox chkIsAvailable;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Panel pnlIngredients;
        private System.Windows.Forms.Label lblIngredientsTitle;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.Label lblQuantityRequired;
        private System.Windows.Forms.NumericUpDown nudQuantityRequired;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.Label lblLinkedIngredients;
        private System.Windows.Forms.DataGridView dgvLinkedIngredients;
        private System.Windows.Forms.Button btnRemoveIngredient;
    }
}