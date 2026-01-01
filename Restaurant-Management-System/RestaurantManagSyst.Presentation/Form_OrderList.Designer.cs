namespace RestaurantManagSyst.Presentation
{
    partial class Form_OrderList
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.SplitContainer();
            this.pnlOrderCreation = new System.Windows.Forms.Panel();
            this.pnlOrderItems = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnClearOrder = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.lblOrderItems = new System.Windows.Forms.Label();
            this.pnlAddItem = new System.Windows.Forms.Panel();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmbMenuItem = new System.Windows.Forms.ComboBox();
            this.lblMenuItem = new System.Windows.Forms.Label();
            this.pnlOrderInfo = new System.Windows.Forms.Panel();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtTableNumber = new System.Windows.Forms.TextBox();
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblCreateOrder = new System.Windows.Forms.Label();
            this.pnlOrdersList = new System.Windows.Forms.Panel();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.txtTips = new System.Windows.Forms.TextBox();
            this.lblTips = new System.Windows.Forms.Label();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.pnlOrderManagement = new System.Windows.Forms.Panel();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblOrderManagement = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.Panel1.SuspendLayout();
            this.pnlMain.Panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlOrderCreation.SuspendLayout();
            this.pnlOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.pnlAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.pnlOrderInfo.SuspendLayout();
            this.pnlOrdersList.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.pnlOrderManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTotalOrders);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(27, 25, 27, 12);
            this.pnlTop.Size = new System.Drawing.Size(1867, 98);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalOrders.Location = new System.Drawing.Point(1291, 70);
            this.lblTotalOrders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(507, 28);
            this.lblTotalOrders.TabIndex = 4;
            this.lblTotalOrders.Text = "Total: 0 commande(s)";
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnRefresh.Location = new System.Drawing.Point(938, 47);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(129, 38);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "🔄";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteOrder.FlatAppearance.BorderSize = 0;
            this.btnDeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteOrder.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOrder.Location = new System.Drawing.Point(438, 51);
            this.btnDeleteOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(120, 43);
            this.btnDeleteOrder.TabIndex = 3;
            this.btnDeleteOrder.Text = "🗑️ Supprimer";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(305, 52);
            this.btnUpdateStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(107, 43);
            this.btnUpdateStatus.TabIndex = 2;
            this.btnUpdateStatus.Text = "📝 Statut";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(31, 53);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(221, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "🔍 Rechercher commandes";
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 98);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlMain.Panel1
            // 
            this.pnlMain.Panel1.Controls.Add(this.pnlOrderCreation);
            this.pnlMain.Panel1MinSize = 600;
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.pnlOrdersList);
            this.pnlMain.Panel2MinSize = 600;
            this.pnlMain.Size = new System.Drawing.Size(1867, 825);
            this.pnlMain.SplitterDistance = 933;
            this.pnlMain.SplitterWidth = 5;
            this.pnlMain.TabIndex = 1;
            // 
            // pnlOrderCreation
            // 
            this.pnlOrderCreation.BackColor = System.Drawing.Color.White;
            this.pnlOrderCreation.Controls.Add(this.pnlOrderItems);
            this.pnlOrderCreation.Controls.Add(this.pnlAddItem);
            this.pnlOrderCreation.Controls.Add(this.pnlOrderInfo);
            this.pnlOrderCreation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderCreation.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderCreation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrderCreation.Name = "pnlOrderCreation";
            this.pnlOrderCreation.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlOrderCreation.Size = new System.Drawing.Size(933, 825);
            this.pnlOrderCreation.TabIndex = 0;
            // 
            // pnlOrderItems
            // 
            this.pnlOrderItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlOrderItems.Controls.Add(this.lblTotalAmount);
            this.pnlOrderItems.Controls.Add(this.btnClearOrder);
            this.pnlOrderItems.Controls.Add(this.btnPlaceOrder);
            this.pnlOrderItems.Controls.Add(this.dgvOrderItems);
            this.pnlOrderItems.Controls.Add(this.lblOrderItems);
            this.pnlOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderItems.Location = new System.Drawing.Point(27, 370);
            this.pnlOrderItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrderItems.Name = "pnlOrderItems";
            this.pnlOrderItems.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlOrderItems.Size = new System.Drawing.Size(879, 430);
            this.pnlOrderItems.TabIndex = 2;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 344);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(400, 37);
            this.lblTotalAmount.TabIndex = 4;
            this.lblTotalAmount.Text = "Total: 0,00 €";
            // 
            // btnClearOrder
            // 
            this.btnClearOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClearOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearOrder.FlatAppearance.BorderSize = 0;
            this.btnClearOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearOrder.ForeColor = System.Drawing.Color.White;
            this.btnClearOrder.Location = new System.Drawing.Point(599, 344);
            this.btnClearOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearOrder.Name = "btnClearOrder";
            this.btnClearOrder.Size = new System.Drawing.Size(120, 49);
            this.btnClearOrder.TabIndex = 3;
            this.btnClearOrder.Text = "Effacer";
            this.btnClearOrder.UseVisualStyleBackColor = false;
            this.btnClearOrder.Click += new System.EventHandler(this.btnClearOrder_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnPlaceOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlaceOrder.FlatAppearance.BorderSize = 0;
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.Location = new System.Drawing.Point(732, 344);
            this.btnPlaceOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(127, 49);
            this.btnPlaceOrder.TabIndex = 2;
            this.btnPlaceOrder.Text = "✅ Passer";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(20, 49);
            this.dgvOrderItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.Size = new System.Drawing.Size(839, 282);
            this.dgvOrderItems.TabIndex = 1;
            this.dgvOrderItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellClick);
            // 
            // lblOrderItems
            // 
            this.lblOrderItems.AutoSize = true;
            this.lblOrderItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOrderItems.Location = new System.Drawing.Point(20, 18);
            this.lblOrderItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderItems.Name = "lblOrderItems";
            this.lblOrderItems.Size = new System.Drawing.Size(160, 28);
            this.lblOrderItems.TabIndex = 0;
            this.lblOrderItems.Text = "Articles ajoutés";
            // 
            // pnlAddItem
            // 
            this.pnlAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlAddItem.Controls.Add(this.lblItemPrice);
            this.pnlAddItem.Controls.Add(this.btnAddItem);
            this.pnlAddItem.Controls.Add(this.nudQuantity);
            this.pnlAddItem.Controls.Add(this.lblQuantity);
            this.pnlAddItem.Controls.Add(this.cmbMenuItem);
            this.pnlAddItem.Controls.Add(this.lblMenuItem);
            this.pnlAddItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAddItem.Location = new System.Drawing.Point(27, 247);
            this.pnlAddItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlAddItem.Name = "pnlAddItem";
            this.pnlAddItem.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlAddItem.Size = new System.Drawing.Size(879, 123);
            this.pnlAddItem.TabIndex = 1;
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblItemPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblItemPrice.Location = new System.Drawing.Point(400, 62);
            this.lblItemPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(58, 23);
            this.lblItemPrice.TabIndex = 5;
            this.lblItemPrice.Text = "Prix: -";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(732, 55);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(127, 43);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "➕ Ajouter";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudQuantity.Location = new System.Drawing.Point(267, 59);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(107, 32);
            this.nudQuantity.TabIndex = 3;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblQuantity.Location = new System.Drawing.Point(267, 31);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(77, 23);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Quantité";
            // 
            // cmbMenuItem
            // 
            this.cmbMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbMenuItem.FormattingEnabled = true;
            this.cmbMenuItem.Location = new System.Drawing.Point(20, 59);
            this.cmbMenuItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMenuItem.Name = "cmbMenuItem";
            this.cmbMenuItem.Size = new System.Drawing.Size(225, 33);
            this.cmbMenuItem.TabIndex = 1;
            this.cmbMenuItem.SelectedIndexChanged += new System.EventHandler(this.cmbMenuItem_SelectedIndexChanged);
            // 
            // lblMenuItem
            // 
            this.lblMenuItem.AutoSize = true;
            this.lblMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMenuItem.Location = new System.Drawing.Point(20, 31);
            this.lblMenuItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuItem.Name = "lblMenuItem";
            this.lblMenuItem.Size = new System.Drawing.Size(58, 23);
            this.lblMenuItem.TabIndex = 0;
            this.lblMenuItem.Text = "Article";
            // 
            // pnlOrderInfo
            // 
            this.pnlOrderInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlOrderInfo.Controls.Add(this.txtNotes);
            this.pnlOrderInfo.Controls.Add(this.lblNotes);
            this.pnlOrderInfo.Controls.Add(this.txtTableNumber);
            this.pnlOrderInfo.Controls.Add(this.lblTableNumber);
            this.pnlOrderInfo.Controls.Add(this.cmbEmployee);
            this.pnlOrderInfo.Controls.Add(this.lblEmployee);
            this.pnlOrderInfo.Controls.Add(this.cmbClient);
            this.pnlOrderInfo.Controls.Add(this.lblClient);
            this.pnlOrderInfo.Controls.Add(this.lblCreateOrder);
            this.pnlOrderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderInfo.Location = new System.Drawing.Point(27, 25);
            this.pnlOrderInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrderInfo.Name = "pnlOrderInfo";
            this.pnlOrderInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlOrderInfo.Size = new System.Drawing.Size(879, 222);
            this.pnlOrderInfo.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(533, 62);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(325, 147);
            this.txtNotes.TabIndex = 8;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNotes.Location = new System.Drawing.Point(533, 31);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(55, 23);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Notes";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTableNumber.Location = new System.Drawing.Point(267, 148);
            this.txtTableNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.Size = new System.Drawing.Size(239, 32);
            this.txtTableNumber.TabIndex = 6;
            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTableNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTableNumber.Location = new System.Drawing.Point(267, 117);
            this.lblTableNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(116, 23);
            this.lblTableNumber.TabIndex = 5;
            this.lblTableNumber.Text = "Numéro table";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(20, 148);
            this.cmbEmployee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(225, 33);
            this.cmbEmployee.TabIndex = 4;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmployee.Location = new System.Drawing.Point(20, 117);
            this.lblEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(75, 23);
            this.lblEmployee.TabIndex = 3;
            this.lblEmployee.Text = "Employé";
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(20, 62);
            this.cmbClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(225, 33);
            this.cmbClient.TabIndex = 2;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblClient.Location = new System.Drawing.Point(20, 31);
            this.lblClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(54, 23);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Client";
            // 
            // lblCreateOrder
            // 
            this.lblCreateOrder.AutoSize = true;
            this.lblCreateOrder.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCreateOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCreateOrder.Location = new System.Drawing.Point(267, 31);
            this.lblCreateOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreateOrder.Name = "lblCreateOrder";
            this.lblCreateOrder.Size = new System.Drawing.Size(259, 32);
            this.lblCreateOrder.TabIndex = 0;
            this.lblCreateOrder.Text = "Créer une commande";
            // 
            // pnlOrdersList
            // 
            this.pnlOrdersList.BackColor = System.Drawing.Color.White;
            this.pnlOrdersList.Controls.Add(this.pnlPayment);
            this.pnlOrdersList.Controls.Add(this.pnlOrderManagement);
            this.pnlOrdersList.Controls.Add(this.dgvOrders);
            this.pnlOrdersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrdersList.Location = new System.Drawing.Point(0, 0);
            this.pnlOrdersList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrdersList.Name = "pnlOrdersList";
            this.pnlOrdersList.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlOrdersList.Size = new System.Drawing.Size(929, 825);
            this.pnlOrdersList.TabIndex = 0;
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlPayment.Controls.Add(this.dgvPayments);
            this.pnlPayment.Controls.Add(this.btnAddPayment);
            this.pnlPayment.Controls.Add(this.txtTips);
            this.pnlPayment.Controls.Add(this.lblTips);
            this.pnlPayment.Controls.Add(this.txtPaymentAmount);
            this.pnlPayment.Controls.Add(this.lblPaymentAmount);
            this.pnlPayment.Controls.Add(this.cmbPaymentMethod);
            this.pnlPayment.Controls.Add(this.lblPaymentMethod);
            this.pnlPayment.Controls.Add(this.lblPayment);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPayment.Location = new System.Drawing.Point(27, 493);
            this.pnlPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlPayment.Size = new System.Drawing.Size(875, 307);
            this.pnlPayment.TabIndex = 2;
            // 
            // dgvPayments
            // 
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPayments.Location = new System.Drawing.Point(20, 147);
            this.dgvPayments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersWidth = 51;
            this.dgvPayments.Size = new System.Drawing.Size(835, 142);
            this.dgvPayments.TabIndex = 8;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPayment.FlatAppearance.BorderSize = 0;
            this.btnAddPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddPayment.ForeColor = System.Drawing.Color.White;
            this.btnAddPayment.Location = new System.Drawing.Point(733, 98);
            this.btnAddPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(120, 43);
            this.btnAddPayment.TabIndex = 7;
            this.btnAddPayment.Text = "➕ Ajouter";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // txtTips
            // 
            this.txtTips.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTips.Location = new System.Drawing.Point(533, 62);
            this.txtTips.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTips.Name = "txtTips";
            this.txtTips.Size = new System.Drawing.Size(172, 32);
            this.txtTips.TabIndex = 6;
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTips.Location = new System.Drawing.Point(533, 31);
            this.lblTips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(84, 23);
            this.lblTips.TabIndex = 5;
            this.lblTips.Text = "Pourboire";
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPaymentAmount.Location = new System.Drawing.Point(267, 62);
            this.txtPaymentAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(239, 32);
            this.txtPaymentAmount.TabIndex = 4;
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentAmount.Location = new System.Drawing.Point(267, 31);
            this.lblPaymentAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(76, 23);
            this.lblPaymentAmount.TabIndex = 3;
            this.lblPaymentAmount.Text = "Montant";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(20, 62);
            this.cmbPaymentMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(225, 33);
            this.cmbPaymentMethod.TabIndex = 2;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 31);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(180, 23);
            this.lblPaymentMethod.TabIndex = 1;
            this.lblPaymentMethod.Text = "Méthode de paiement";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPayment.Location = new System.Drawing.Point(20, 0);
            this.lblPayment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(244, 28);
            this.lblPayment.TabIndex = 0;
            this.lblPayment.Text = "💳 Traitement paiement";
            // 
            // pnlOrderManagement
            // 
            this.pnlOrderManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlOrderManagement.Controls.Add(this.cmbStatus);
            this.pnlOrderManagement.Controls.Add(this.lblStatus);
            this.pnlOrderManagement.Controls.Add(this.btnDeleteOrder);
            this.pnlOrderManagement.Controls.Add(this.lblOrderManagement);
            this.pnlOrderManagement.Controls.Add(this.btnUpdateStatus);
            this.pnlOrderManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderManagement.Location = new System.Drawing.Point(27, 333);
            this.pnlOrderManagement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrderManagement.Name = "pnlOrderManagement";
            this.pnlOrderManagement.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlOrderManagement.Size = new System.Drawing.Size(875, 160);
            this.pnlOrderManagement.TabIndex = 1;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Preparing",
            "Ready",
            "Completed",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(20, 62);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(265, 33);
            this.cmbStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 31);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 23);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Statut";
            // 
            // lblOrderManagement
            // 
            this.lblOrderManagement.AutoSize = true;
            this.lblOrderManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOrderManagement.Location = new System.Drawing.Point(20, 0);
            this.lblOrderManagement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderManagement.Name = "lblOrderManagement";
            this.lblOrderManagement.Size = new System.Drawing.Size(275, 28);
            this.lblOrderManagement.TabIndex = 0;
            this.lblOrderManagement.Text = "📋 Gestion des commandes";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvOrders.Location = new System.Drawing.Point(27, 25);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(875, 308);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // Form_OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1867, 923);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_OrderList";
            this.Text = "Gestion des Commandes";
            this.Load += new System.EventHandler(this.Form_OrderList_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.Panel1.ResumeLayout(false);
            this.pnlMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlOrderCreation.ResumeLayout(false);
            this.pnlOrderItems.ResumeLayout(false);
            this.pnlOrderItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.pnlAddItem.ResumeLayout(false);
            this.pnlAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.pnlOrderInfo.ResumeLayout(false);
            this.pnlOrderInfo.PerformLayout();
            this.pnlOrdersList.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.pnlPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.pnlOrderManagement.ResumeLayout(false);
            this.pnlOrderManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.SplitContainer pnlMain;
        private System.Windows.Forms.Panel pnlOrderCreation;
        private System.Windows.Forms.Panel pnlOrderItems;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnClearOrder;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label lblOrderItems;
        private System.Windows.Forms.Panel pnlAddItem;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cmbMenuItem;
        private System.Windows.Forms.Label lblMenuItem;
        private System.Windows.Forms.Panel pnlOrderInfo;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtTableNumber;
        private System.Windows.Forms.Label lblTableNumber;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblCreateOrder;
        private System.Windows.Forms.Panel pnlOrdersList;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.TextBox txtTips;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Panel pnlOrderManagement;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblOrderManagement;
    }
}
