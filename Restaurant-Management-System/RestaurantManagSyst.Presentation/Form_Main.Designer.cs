namespace RestaurantManagSyst.Presentation
{
    partial class Form_Main
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

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.pnlMenuButtons = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPaymentMethods = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnIngredients = new System.Windows.Forms.Button();
            this.btnMenuItems = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.pnlMenuButtons.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.pnlSidebar.Controls.Add(this.pnlUserInfo);
            this.pnlSidebar.Controls.Add(this.pnlMenuButtons);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 800);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlUserInfo.Controls.Add(this.lblUserRole);
            this.pnlUserInfo.Controls.Add(this.lblUsername);
            this.pnlUserInfo.Controls.Add(this.picUser);
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserInfo.Location = new System.Drawing.Point(0, 700);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(250, 100);
            this.pnlUserInfo.TabIndex = 2;
            // 
            // lblUserRole
            // 
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserRole.ForeColor = System.Drawing.Color.LightGray;
            this.lblUserRole.Location = new System.Drawing.Point(70, 45);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(170, 20);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Admin";
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(70, 25);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(170, 25);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.White;
            this.picUser.Location = new System.Drawing.Point(15, 25);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(50, 50);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 0;
            this.picUser.TabStop = false;
            // 
            // pnlMenuButtons
            // 
            this.pnlMenuButtons.Controls.Add(this.btnLogout);
            this.pnlMenuButtons.Controls.Add(this.btnPaymentMethods);
            this.pnlMenuButtons.Controls.Add(this.btnInventory);
            this.pnlMenuButtons.Controls.Add(this.btnIngredients);
            this.pnlMenuButtons.Controls.Add(this.btnMenuItems);
            this.pnlMenuButtons.Controls.Add(this.btnEmployees);
            this.pnlMenuButtons.Controls.Add(this.btnClients);
            this.pnlMenuButtons.Controls.Add(this.btnOrders);
            this.pnlMenuButtons.Controls.Add(this.btnDashboard);
            this.pnlMenuButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuButtons.Location = new System.Drawing.Point(0, 100);
            this.pnlMenuButtons.Name = "pnlMenuButtons";
            this.pnlMenuButtons.Size = new System.Drawing.Size(250, 700);
            this.pnlMenuButtons.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            //this.btnLogout.Image = global::RestaurantManagSyst.Presentation.Properties.Resources.logout_icon;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 400);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(250, 50);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "   Déconnexion";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnLogout.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnPaymentMethods
            // 
            this.btnPaymentMethods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaymentMethods.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPaymentMethods.FlatAppearance.BorderSize = 0;
            this.btnPaymentMethods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentMethods.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPaymentMethods.ForeColor = System.Drawing.Color.White;
            this.btnPaymentMethods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymentMethods.Location = new System.Drawing.Point(0, 350);
            this.btnPaymentMethods.Name = "btnPaymentMethods";
            this.btnPaymentMethods.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPaymentMethods.Size = new System.Drawing.Size(250, 50);
            this.btnPaymentMethods.TabIndex = 7;
            this.btnPaymentMethods.Text = "💳  Paiements";
            this.btnPaymentMethods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymentMethods.UseVisualStyleBackColor = true;
            this.btnPaymentMethods.Click += new System.EventHandler(this.btnPaymentMethods_Click);
            this.btnPaymentMethods.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnPaymentMethods.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnInventory
            // 
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(0, 300);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnInventory.Size = new System.Drawing.Size(250, 50);
            this.btnInventory.TabIndex = 6;
            this.btnInventory.Text = "📦  Inventaire";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            this.btnInventory.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnInventory.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnIngredients
            // 
            this.btnIngredients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngredients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngredients.FlatAppearance.BorderSize = 0;
            this.btnIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngredients.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnIngredients.ForeColor = System.Drawing.Color.White;
            this.btnIngredients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngredients.Location = new System.Drawing.Point(0, 250);
            this.btnIngredients.Name = "btnIngredients";
            this.btnIngredients.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnIngredients.Size = new System.Drawing.Size(250, 50);
            this.btnIngredients.TabIndex = 5;
            this.btnIngredients.Text = "🧂  Ingrédients";
            this.btnIngredients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngredients.UseVisualStyleBackColor = true;
            this.btnIngredients.Click += new System.EventHandler(this.btnIngredients_Click);
            this.btnIngredients.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnIngredients.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnMenuItems
            // 
            this.btnMenuItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuItems.FlatAppearance.BorderSize = 0;
            this.btnMenuItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuItems.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMenuItems.ForeColor = System.Drawing.Color.White;
            this.btnMenuItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuItems.Location = new System.Drawing.Point(0, 200);
            this.btnMenuItems.Name = "btnMenuItems";
            this.btnMenuItems.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuItems.Size = new System.Drawing.Size(250, 50);
            this.btnMenuItems.TabIndex = 4;
            this.btnMenuItems.Text = "🍔  Menu";
            this.btnMenuItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuItems.UseVisualStyleBackColor = true;
            this.btnMenuItems.Click += new System.EventHandler(this.btnMenuItems_Click);
            this.btnMenuItems.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnMenuItems.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(0, 150);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEmployees.Size = new System.Drawing.Size(250, 50);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "👨‍🍳  Employés";
            this.btnEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            this.btnEmployees.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnEmployees.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnClients
            // 
            this.btnClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(0, 100);
            this.btnClients.Name = "btnClients";
            this.btnClients.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnClients.Size = new System.Drawing.Size(250, 50);
            this.btnClients.TabIndex = 2;
            this.btnClients.Text = "👥  Clients";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            this.btnClients.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnClients.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnOrders
            // 
            this.btnOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOrders.ForeColor = System.Drawing.Color.White;
            this.btnOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.Location = new System.Drawing.Point(0, 50);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnOrders.Size = new System.Drawing.Size(250, 50);
            this.btnOrders.TabIndex = 1;
            this.btnOrders.Text = "🛒  Commandes";
            this.btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            this.btnOrders.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnOrders.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(250, 50);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊  Tableau de bord";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            this.btnDashboard.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnDashboard.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlLogo.Controls.Add(this.lblAppName);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(250, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(0, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(250, 100);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "🍽️ Restaurant\r\nManager";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblFormTitle);
            this.pnlTop.Controls.Add(this.btnMinimize);
            this.pnlTop.Controls.Add(this.btnMaximize);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(250, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1150, 50);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFormTitle.Location = new System.Drawing.Point(20, 12);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(172, 25);
            this.lblFormTitle.TabIndex = 3;
            this.lblFormTitle.Text = "Tableau de bord";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimize.Location = new System.Drawing.Point(1030, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 50);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "─";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMaximize.Location = new System.Drawing.Point(1070, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(40, 50);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.Text = "⬜";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Location = new System.Drawing.Point(1110, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 50);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(250, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1150, 750);
            this.pnlContent.TabIndex = 2;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.pnlMenuButtons.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel pnlMenuButtons;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnMenuItems;
        private System.Windows.Forms.Button btnIngredients;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnPaymentMethods;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlContent;
    }
}