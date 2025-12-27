namespace RestaurantManagSyst.Presentation
{
    partial class Form_Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlOrdersCard = new System.Windows.Forms.Panel();
            this.lblPendingOrders = new System.Windows.Forms.Label();
            this.lblPendingOrdersLabel = new System.Windows.Forms.Label();
            this.lblCompletedOrders = new System.Windows.Forms.Label();
            this.lblCompletedOrdersLabel = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.lblOrdersIcon = new System.Windows.Forms.Label();
            this.pnlUsersCard = new System.Windows.Forms.Panel();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.lblUsersTitle = new System.Windows.Forms.Label();
            this.lblUsersIcon = new System.Windows.Forms.Label();
            this.pnlProductsCard = new System.Windows.Forms.Panel();
            this.lblActiveProducts = new System.Windows.Forms.Label();
            this.lblActiveProductsLabel = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.lblProductsIcon = new System.Windows.Forms.Label();
            this.pnlPaymentMethodsCard = new System.Windows.Forms.Panel();
            this.lblActivePaymentMethods = new System.Windows.Forms.Label();
            this.lblActiveLabel = new System.Windows.Forms.Label();
            this.lblTotalPaymentMethods = new System.Windows.Forms.Label();
            this.lblPaymentMethodsTitle = new System.Windows.Forms.Label();
            this.lblPaymentMethodsIcon = new System.Windows.Forms.Label();
            this.pnlEmployeesCard = new System.Windows.Forms.Panel();
            this.lblTotalEmployees = new System.Windows.Forms.Label();
            this.lblEmployeesTitle = new System.Windows.Forms.Label();
            this.lblEmployeesIcon = new System.Windows.Forms.Label();
            this.pnlClientsCard = new System.Windows.Forms.Panel();
            this.lblTotalClients = new System.Windows.Forms.Label();
            this.lblClientsTitle = new System.Windows.Forms.Label();
            this.lblClientsIcon = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlOrdersCard.SuspendLayout();
            this.pnlUsersCard.SuspendLayout();
            this.pnlProductsCard.SuspendLayout();
            this.pnlPaymentMethodsCard.SuspendLayout();
            this.pnlEmployeesCard.SuspendLayout();
            this.pnlClientsCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.lblWelcome);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlTop.Size = new System.Drawing.Size(1150, 100);
            this.pnlTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1000, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Actualiser";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWelcome.Location = new System.Drawing.Point(30, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(359, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "📊 Tableau de bord";
            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCards.Controls.Add(this.pnlOrdersCard);
            this.pnlCards.Controls.Add(this.pnlUsersCard);
            this.pnlCards.Controls.Add(this.pnlProductsCard);
            this.pnlCards.Controls.Add(this.pnlPaymentMethodsCard);
            this.pnlCards.Controls.Add(this.pnlEmployeesCard);
            this.pnlCards.Controls.Add(this.pnlClientsCard);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCards.Location = new System.Drawing.Point(0, 100);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(30);
            this.pnlCards.Size = new System.Drawing.Size(1150, 650);
            this.pnlCards.TabIndex = 1;
            // 
            // pnlOrdersCard
            // 
            this.pnlOrdersCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.pnlOrdersCard.Controls.Add(this.lblPendingOrders);
            this.pnlOrdersCard.Controls.Add(this.lblPendingOrdersLabel);
            this.pnlOrdersCard.Controls.Add(this.lblCompletedOrders);
            this.pnlOrdersCard.Controls.Add(this.lblCompletedOrdersLabel);
            this.pnlOrdersCard.Controls.Add(this.lblTotalOrders);
            this.pnlOrdersCard.Controls.Add(this.lblOrdersTitle);
            this.pnlOrdersCard.Controls.Add(this.lblOrdersIcon);
            this.pnlOrdersCard.Location = new System.Drawing.Point(30, 50);
            this.pnlOrdersCard.Name = "pnlOrdersCard";
            this.pnlOrdersCard.Size = new System.Drawing.Size(250, 180);
            this.pnlOrdersCard.TabIndex = 5;
            // 
            // lblPendingOrders
            // 
            this.lblPendingOrders.AutoSize = true;
            this.lblPendingOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingOrders.ForeColor = System.Drawing.Color.White;
            this.lblPendingOrders.Location = new System.Drawing.Point(120, 145);
            this.lblPendingOrders.Name = "lblPendingOrders";
            this.lblPendingOrders.Size = new System.Drawing.Size(18, 20);
            this.lblPendingOrders.TabIndex = 6;
            this.lblPendingOrders.Text = "0";
            // 
            // lblPendingOrdersLabel
            // 
            this.lblPendingOrdersLabel.AutoSize = true;
            this.lblPendingOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingOrdersLabel.ForeColor = System.Drawing.Color.White;
            this.lblPendingOrdersLabel.Location = new System.Drawing.Point(21, 145);
            this.lblPendingOrdersLabel.Name = "lblPendingOrdersLabel";
            this.lblPendingOrdersLabel.Size = new System.Drawing.Size(93, 15);
            this.lblPendingOrdersLabel.TabIndex = 5;
            this.lblPendingOrdersLabel.Text = "En attente:";
            // 
            // lblCompletedOrders
            // 
            this.lblCompletedOrders.AutoSize = true;
            this.lblCompletedOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedOrders.ForeColor = System.Drawing.Color.White;
            this.lblCompletedOrders.Location = new System.Drawing.Point(120, 125);
            this.lblCompletedOrders.Name = "lblCompletedOrders";
            this.lblCompletedOrders.Size = new System.Drawing.Size(18, 20);
            this.lblCompletedOrders.TabIndex = 4;
            this.lblCompletedOrders.Text = "0";
            // 
            // lblCompletedOrdersLabel
            // 
            this.lblCompletedOrdersLabel.AutoSize = true;
            this.lblCompletedOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedOrdersLabel.ForeColor = System.Drawing.Color.White;
            this.lblCompletedOrdersLabel.Location = new System.Drawing.Point(21, 125);
            this.lblCompletedOrdersLabel.Name = "lblCompletedOrdersLabel";
            this.lblCompletedOrdersLabel.Size = new System.Drawing.Size(93, 15);
            this.lblCompletedOrdersLabel.TabIndex = 3;
            this.lblCompletedOrdersLabel.Text = "Complétées:";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrders.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrders.Location = new System.Drawing.Point(20, 80);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(210, 40);
            this.lblTotalOrders.TabIndex = 2;
            this.lblTotalOrders.Text = "0";
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.White;
            this.lblOrdersTitle.Location = new System.Drawing.Point(20, 45);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Size = new System.Drawing.Size(142, 21);
            this.lblOrdersTitle.TabIndex = 1;
            this.lblOrdersTitle.Text = "Total Commandes";
            // 
            // lblOrdersIcon
            // 
            this.lblOrdersIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrdersIcon.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersIcon.Location = new System.Drawing.Point(160, 15);
            this.lblOrdersIcon.Name = "lblOrdersIcon";
            this.lblOrdersIcon.Size = new System.Drawing.Size(70, 60);
            this.lblOrdersIcon.TabIndex = 0;
            this.lblOrdersIcon.Text = "🛒";
            this.lblOrdersIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUsersCard
            // 
            this.pnlUsersCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
            this.pnlUsersCard.Controls.Add(this.lblTotalUsers);
            this.pnlUsersCard.Controls.Add(this.lblUsersTitle);
            this.pnlUsersCard.Controls.Add(this.lblUsersIcon);
            this.pnlUsersCard.Location = new System.Drawing.Point(610, 280);
            this.pnlUsersCard.Name = "pnlUsersCard";
            this.pnlUsersCard.Size = new System.Drawing.Size(250, 180);
            this.pnlUsersCard.TabIndex = 3;
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsers.ForeColor = System.Drawing.Color.White;
            this.lblTotalUsers.Location = new System.Drawing.Point(20, 80);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(210, 65);
            this.lblTotalUsers.TabIndex = 2;
            this.lblTotalUsers.Text = "0";
            this.lblTotalUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsersTitle
            // 
            this.lblUsersTitle.AutoSize = true;
            this.lblUsersTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersTitle.ForeColor = System.Drawing.Color.White;
            this.lblUsersTitle.Location = new System.Drawing.Point(20, 45);
            this.lblUsersTitle.Name = "lblUsersTitle";
            this.lblUsersTitle.Size = new System.Drawing.Size(147, 21);
            this.lblUsersTitle.TabIndex = 1;
            this.lblUsersTitle.Text = "Total Utilisateurs";
            // 
            // lblUsersIcon
            // 
            this.lblUsersIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsersIcon.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersIcon.Location = new System.Drawing.Point(160, 15);
            this.lblUsersIcon.Name = "lblUsersIcon";
            this.lblUsersIcon.Size = new System.Drawing.Size(70, 60);
            this.lblUsersIcon.TabIndex = 0;
            this.lblUsersIcon.Text = "👤";
            this.lblUsersIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProductsCard
            // 
            this.pnlProductsCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.pnlProductsCard.Controls.Add(this.lblActiveProducts);
            this.pnlProductsCard.Controls.Add(this.lblActiveProductsLabel);
            this.pnlProductsCard.Controls.Add(this.lblTotalProducts);
            this.pnlProductsCard.Controls.Add(this.lblProductsTitle);
            this.pnlProductsCard.Controls.Add(this.lblProductsIcon);
            this.pnlProductsCard.Location = new System.Drawing.Point(30, 280);
            this.pnlProductsCard.Name = "pnlProductsCard";
            this.pnlProductsCard.Size = new System.Drawing.Size(250, 180);
            this.pnlProductsCard.TabIndex = 4;
            // 
            // lblActiveProducts
            // 
            this.lblActiveProducts.AutoSize = true;
            this.lblActiveProducts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveProducts.ForeColor = System.Drawing.Color.White;
            this.lblActiveProducts.Location = new System.Drawing.Point(85, 145);
            this.lblActiveProducts.Name = "lblActiveProducts";
            this.lblActiveProducts.Size = new System.Drawing.Size(18, 20);
            this.lblActiveProducts.TabIndex = 4;
            this.lblActiveProducts.Text = "0";
            // 
            // lblActiveProductsLabel
            // 
            this.lblActiveProductsLabel.AutoSize = true;
            this.lblActiveProductsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveProductsLabel.ForeColor = System.Drawing.Color.White;
            this.lblActiveProductsLabel.Location = new System.Drawing.Point(21, 145);
            this.lblActiveProductsLabel.Name = "lblActiveProductsLabel";
            this.lblActiveProductsLabel.Size = new System.Drawing.Size(58, 15);
            this.lblActiveProductsLabel.TabIndex = 3;
            this.lblActiveProductsLabel.Text = "Active(s):";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProducts.ForeColor = System.Drawing.Color.White;
            this.lblTotalProducts.Location = new System.Drawing.Point(20, 80);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(210, 65);
            this.lblTotalProducts.TabIndex = 2;
            this.lblTotalProducts.Text = "0";
            this.lblTotalProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductsTitle
            // 
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsTitle.ForeColor = System.Drawing.Color.White;
            this.lblProductsTitle.Location = new System.Drawing.Point(20, 45);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Size = new System.Drawing.Size(116, 21);
            this.lblProductsTitle.TabIndex = 1;
            this.lblProductsTitle.Text = "Total Produits";
            // 
            // lblProductsIcon
            // 
            this.lblProductsIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductsIcon.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsIcon.Location = new System.Drawing.Point(160, 15);
            this.lblProductsIcon.Name = "lblProductsIcon";
            this.lblProductsIcon.Size = new System.Drawing.Size(70, 60);
            this.lblProductsIcon.TabIndex = 0;
            this.lblProductsIcon.Text = "🍔";
            this.lblProductsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPaymentMethodsCard
            // 
            this.pnlPaymentMethodsCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.pnlPaymentMethodsCard.Controls.Add(this.lblActivePaymentMethods);
            this.pnlPaymentMethodsCard.Controls.Add(this.lblActiveLabel);
            this.pnlPaymentMethodsCard.Controls.Add(this.lblTotalPaymentMethods);
            this.pnlPaymentMethodsCard.Controls.Add(this.lblPaymentMethodsTitle);
            this.pnlPaymentMethodsCard.Controls.Add(this.lblPaymentMethodsIcon);
            this.pnlPaymentMethodsCard.Location = new System.Drawing.Point(310, 280);
            this.pnlPaymentMethodsCard.Name = "pnlPaymentMethodsCard";
            this.pnlPaymentMethodsCard.Size = new System.Drawing.Size(250, 180);
            this.pnlPaymentMethodsCard.TabIndex = 2;
            // 
            // lblActivePaymentMethods
            // 
            this.lblActivePaymentMethods.AutoSize = true;
            this.lblActivePaymentMethods.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivePaymentMethods.ForeColor = System.Drawing.Color.White;
            this.lblActivePaymentMethods.Location = new System.Drawing.Point(85, 145);
            this.lblActivePaymentMethods.Name = "lblActivePaymentMethods";
            this.lblActivePaymentMethods.Size = new System.Drawing.Size(18, 20);
            this.lblActivePaymentMethods.TabIndex = 4;
            this.lblActivePaymentMethods.Text = "0";
            // 
            // lblActiveLabel
            // 
            this.lblActiveLabel.AutoSize = true;
            this.lblActiveLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveLabel.ForeColor = System.Drawing.Color.White;
            this.lblActiveLabel.Location = new System.Drawing.Point(21, 145);
            this.lblActiveLabel.Name = "lblActiveLabel";
            this.lblActiveLabel.Size = new System.Drawing.Size(58, 15);
            this.lblActiveLabel.TabIndex = 3;
            this.lblActiveLabel.Text = "Active(s):";
            // 
            // lblTotalPaymentMethods
            // 
            this.lblTotalPaymentMethods.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaymentMethods.ForeColor = System.Drawing.Color.White;
            this.lblTotalPaymentMethods.Location = new System.Drawing.Point(20, 80);
            this.lblTotalPaymentMethods.Name = "lblTotalPaymentMethods";
            this.lblTotalPaymentMethods.Size = new System.Drawing.Size(210, 65);
            this.lblTotalPaymentMethods.TabIndex = 2;
            this.lblTotalPaymentMethods.Text = "0";
            this.lblTotalPaymentMethods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPaymentMethodsTitle
            // 
            this.lblPaymentMethodsTitle.AutoSize = true;
            this.lblPaymentMethodsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethodsTitle.ForeColor = System.Drawing.Color.White;
            this.lblPaymentMethodsTitle.Location = new System.Drawing.Point(20, 45);
            this.lblPaymentMethodsTitle.Name = "lblPaymentMethodsTitle";
            this.lblPaymentMethodsTitle.Size = new System.Drawing.Size(150, 20);
            this.lblPaymentMethodsTitle.TabIndex = 1;
            this.lblPaymentMethodsTitle.Text = "Méthodes Paiement";
            // 
            // lblPaymentMethodsIcon
            // 
            this.lblPaymentMethodsIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaymentMethodsIcon.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethodsIcon.Location = new System.Drawing.Point(160, 15);
            this.lblPaymentMethodsIcon.Name = "lblPaymentMethodsIcon";
            this.lblPaymentMethodsIcon.Size = new System.Drawing.Size(70, 60);
            this.lblPaymentMethodsIcon.TabIndex = 0;
            this.lblPaymentMethodsIcon.Text = "💳";
            this.lblPaymentMethodsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlEmployeesCard
            // 
            this.pnlEmployeesCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlEmployeesCard.Controls.Add(this.lblTotalEmployees);
            this.pnlEmployeesCard.Controls.Add(this.lblEmployeesTitle);
            this.pnlEmployeesCard.Controls.Add(this.lblEmployeesIcon);
            this.pnlEmployeesCard.Location = new System.Drawing.Point(610, 50);
            this.pnlEmployeesCard.Name = "pnlEmployeesCard";
            this.pnlEmployeesCard.Size = new System.Drawing.Size(250, 180);
            this.pnlEmployeesCard.TabIndex = 1;
            // 
            // lblTotalEmployees
            // 
            this.lblTotalEmployees.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEmployees.ForeColor = System.Drawing.Color.White;
            this.lblTotalEmployees.Location = new System.Drawing.Point(20, 80);
            this.lblTotalEmployees.Name = "lblTotalEmployees";
            this.lblTotalEmployees.Size = new System.Drawing.Size(210, 65);
            this.lblTotalEmployees.TabIndex = 2;
            this.lblTotalEmployees.Text = "0";
            this.lblTotalEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmployeesTitle
            // 
            this.lblEmployeesTitle.AutoSize = true;
            this.lblEmployeesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeesTitle.ForeColor = System.Drawing.Color.White;
            this.lblEmployeesTitle.Location = new System.Drawing.Point(20, 45);
            this.lblEmployeesTitle.Name = "lblEmployeesTitle";
            this.lblEmployeesTitle.Size = new System.Drawing.Size(130, 21);
            this.lblEmployeesTitle.TabIndex = 1;
            this.lblEmployeesTitle.Text = "Total Employés";
            // 
            // lblEmployeesIcon
            // 
            this.lblEmployeesIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmployeesIcon.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeesIcon.Location = new System.Drawing.Point(160, 15);
            this.lblEmployeesIcon.Name = "lblEmployeesIcon";
            this.lblEmployeesIcon.Size = new System.Drawing.Size(70, 60);
            this.lblEmployeesIcon.TabIndex = 0;
            this.lblEmployeesIcon.Text = "👨‍🍳";
            this.lblEmployeesIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlClientsCard
            // 
            this.pnlClientsCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pnlClientsCard.Controls.Add(this.lblTotalClients);
            this.pnlClientsCard.Controls.Add(this.lblClientsTitle);
            this.pnlClientsCard.Controls.Add(this.lblClientsIcon);
            this.pnlClientsCard.Location = new System.Drawing.Point(310, 50);
            this.pnlClientsCard.Name = "pnlClientsCard";
            this.pnlClientsCard.Size = new System.Drawing.Size(250, 180);
            this.pnlClientsCard.TabIndex = 0;
            // 
            // lblTotalClients
            // 
            this.lblTotalClients.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClients.ForeColor = System.Drawing.Color.White;
            this.lblTotalClients.Location = new System.Drawing.Point(20, 80);
            this.lblTotalClients.Name = "lblTotalClients";
            this.lblTotalClients.Size = new System.Drawing.Size(210, 65);
            this.lblTotalClients.TabIndex = 2;
            this.lblTotalClients.Text = "0";
            this.lblTotalClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClientsTitle
            // 
            this.lblClientsTitle.AutoSize = true;
            this.lblClientsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientsTitle.ForeColor = System.Drawing.Color.White;
            this.lblClientsTitle.Location = new System.Drawing.Point(20, 45);
            this.lblClientsTitle.Name = "lblClientsTitle";
            this.lblClientsTitle.Size = new System.Drawing.Size(106, 21);
            this.lblClientsTitle.TabIndex = 1;
            this.lblClientsTitle.Text = "Total Clients";
            // 
            // lblClientsIcon
            // 
            this.lblClientsIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientsIcon.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientsIcon.Location = new System.Drawing.Point(160, 15);
            this.lblClientsIcon.Name = "lblClientsIcon";
            this.lblClientsIcon.Size = new System.Drawing.Size(70, 60);
            this.lblClientsIcon.TabIndex = 0;
            this.lblClientsIcon.Text = "👥";
            this.lblClientsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1150, 750);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Form_Dashboard_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlOrdersCard.ResumeLayout(false);
            this.pnlOrdersCard.PerformLayout();
            this.pnlUsersCard.ResumeLayout(false);
            this.pnlUsersCard.PerformLayout();
            this.pnlProductsCard.ResumeLayout(false);
            this.pnlProductsCard.PerformLayout();
            this.pnlPaymentMethodsCard.ResumeLayout(false);
            this.pnlPaymentMethodsCard.PerformLayout();
            this.pnlEmployeesCard.ResumeLayout(false);
            this.pnlEmployeesCard.PerformLayout();
            this.pnlClientsCard.ResumeLayout(false);
            this.pnlClientsCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlClientsCard;
        private System.Windows.Forms.Label lblClientsIcon;
        private System.Windows.Forms.Label lblClientsTitle;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.Panel pnlEmployeesCard;
        private System.Windows.Forms.Label lblTotalEmployees;
        private System.Windows.Forms.Label lblEmployeesTitle;
        private System.Windows.Forms.Label lblEmployeesIcon;
        private System.Windows.Forms.Panel pnlPaymentMethodsCard;
        private System.Windows.Forms.Label lblTotalPaymentMethods;
        private System.Windows.Forms.Label lblPaymentMethodsTitle;
        private System.Windows.Forms.Label lblPaymentMethodsIcon;
        private System.Windows.Forms.Panel pnlProductsCard;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Label lblProductsIcon;
        private System.Windows.Forms.Label lblActiveProducts;
        private System.Windows.Forms.Label lblActiveProductsLabel;
        private System.Windows.Forms.Panel pnlOrdersCard;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblOrdersIcon;
        private System.Windows.Forms.Label lblCompletedOrders;
        private System.Windows.Forms.Label lblCompletedOrdersLabel;
        private System.Windows.Forms.Label lblPendingOrders;
        private System.Windows.Forms.Label lblPendingOrdersLabel;
        private System.Windows.Forms.Panel pnlUsersCard;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblUsersTitle;
        private System.Windows.Forms.Label lblUsersIcon;
        private System.Windows.Forms.Label lblActivePaymentMethods;
        private System.Windows.Forms.Label lblActiveLabel;
    }
}