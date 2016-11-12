namespace ProposalReportingSystem
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.superTabControl2 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.home_tab = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel8 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem8 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel9 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem9 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel10 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem10 = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).BeginInit();
            this.superTabControl2.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.superTabControlPanel8.SuspendLayout();
            this.superTabControlPanel9.SuspendLayout();
            this.superTabControlPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // superTabControl2
            // 
            this.superTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.superTabControl2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl2.ControlBox.MenuBox.Name = "";
            this.superTabControl2.ControlBox.Name = "";
            this.superTabControl2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl2.ControlBox.MenuBox,
            this.superTabControl2.ControlBox.CloseBox});
            this.superTabControl2.Controls.Add(this.superTabControlPanel2);
            this.superTabControl2.Controls.Add(this.superTabControlPanel10);
            this.superTabControl2.Controls.Add(this.superTabControlPanel9);
            this.superTabControl2.Controls.Add(this.superTabControlPanel8);
            this.superTabControl2.FixedTabSize = new System.Drawing.Size(70, 0);
            this.superTabControl2.Font = new System.Drawing.Font("B Yekan+", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl2.Location = new System.Drawing.Point(-1, 0);
            this.superTabControl2.Name = "superTabControl2";
            this.superTabControl2.ReorderTabsEnabled = true;
            this.superTabControl2.SelectedTabFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl2.SelectedTabIndex = 0;
            this.superTabControl2.Size = new System.Drawing.Size(1041, 676);
            this.superTabControl2.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right;
            this.superTabControl2.TabFont = new System.Drawing.Font("Segoe UI", 9F);
            this.superTabControl2.TabIndex = 2;
            this.superTabControl2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.home_tab,
            this.superTabItem8,
            this.superTabItem9,
            this.superTabItem10});
            this.superTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl2.TabVerticalSpacing = 3;
            this.superTabControl2.Text = "superTabControl2";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.labelX3);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(969, 676);
            this.superTabControlPanel2.TabIndex = 1;
            this.superTabControlPanel2.TabItem = this.home_tab;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(0, 0);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(969, 69);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "Office 2010 Backstage tab style.";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // home_tab
            // 
            this.home_tab.AttachedControl = this.superTabControlPanel2;
            this.home_tab.GlobalItem = false;
            this.home_tab.Icon = ((System.Drawing.Icon)(resources.GetObject("home_tab.Icon")));
            this.home_tab.ImageAlignment = DevComponents.DotNetBar.ImageAlignment.MiddleRight;
            this.home_tab.Name = "home_tab";
            this.home_tab.Text = "خانه";
            // 
            // superTabControlPanel8
            // 
            this.superTabControlPanel8.Controls.Add(this.labelX4);
            this.superTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel8.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel8.Name = "superTabControlPanel8";
            this.superTabControlPanel8.Size = new System.Drawing.Size(969, 676);
            this.superTabControlPanel8.TabIndex = 2;
            this.superTabControlPanel8.TabItem = this.superTabItem8;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX4.Location = new System.Drawing.Point(0, 0);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(969, 676);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "This space intentionally left blank.";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // superTabItem8
            // 
            this.superTabItem8.AttachedControl = this.superTabControlPanel8;
            this.superTabItem8.GlobalItem = false;
            this.superTabItem8.Name = "superTabItem8";
            this.superTabItem8.Text = "Recent";
            // 
            // superTabControlPanel9
            // 
            this.superTabControlPanel9.Controls.Add(this.labelX5);
            this.superTabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel9.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel9.Name = "superTabControlPanel9";
            this.superTabControlPanel9.Size = new System.Drawing.Size(969, 676);
            this.superTabControlPanel9.TabIndex = 3;
            this.superTabControlPanel9.TabItem = this.superTabItem9;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX5.Location = new System.Drawing.Point(0, 0);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(969, 676);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "This space intentionally left blank.";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // superTabItem9
            // 
            this.superTabItem9.AttachedControl = this.superTabControlPanel9;
            this.superTabItem9.GlobalItem = false;
            this.superTabItem9.Name = "superTabItem9";
            this.superTabItem9.Text = "Print";
            // 
            // superTabControlPanel10
            // 
            this.superTabControlPanel10.Controls.Add(this.labelX6);
            this.superTabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel10.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel10.Name = "superTabControlPanel10";
            this.superTabControlPanel10.Size = new System.Drawing.Size(969, 676);
            this.superTabControlPanel10.TabIndex = 4;
            this.superTabControlPanel10.TabItem = this.superTabItem10;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX6.Location = new System.Drawing.Point(0, 0);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(969, 676);
            this.labelX6.TabIndex = 8;
            this.labelX6.Text = "This space intentionally left blank.";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // superTabItem10
            // 
            this.superTabItem10.AttachedControl = this.superTabControlPanel10;
            this.superTabItem10.GlobalItem = false;
            this.superTabItem10.Name = "superTabItem10";
            this.superTabItem10.Text = "Share";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 673);
            this.Controls.Add(this.superTabControl2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).EndInit();
            this.superTabControl2.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel8.ResumeLayout(false);
            this.superTabControlPanel9.ResumeLayout(false);
            this.superTabControlPanel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel10;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.SuperTabItem superTabItem10;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel9;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.SuperTabItem superTabItem9;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel8;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.SuperTabItem superTabItem8;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.SuperTabItem home_tab;
    }
}

