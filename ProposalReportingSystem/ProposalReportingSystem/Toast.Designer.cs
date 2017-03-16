namespace ProposalReportingSystem
{
    partial class Toast
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
            this.toastContextLbl = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toastPanel = new DevComponents.DotNetBar.PanelEx();
            this.toastIconPb = new System.Windows.Forms.PictureBox();
            this.toastPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toastIconPb)).BeginInit();
            this.SuspendLayout();
            // 
            // toastContextLbl
            // 
            this.toastContextLbl.BackColor = System.Drawing.Color.Transparent;
            this.toastContextLbl.Font = new System.Drawing.Font("B Roya", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.toastContextLbl.Location = new System.Drawing.Point(45, 28);
            this.toastContextLbl.Name = "toastContextLbl";
            this.toastContextLbl.Size = new System.Drawing.Size(429, 25);
            this.toastContextLbl.TabIndex = 0;
            this.toastContextLbl.Text = "اطلاعات پروپوزال با موفقیت ثبت شد";
            this.toastContextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toastPanel
            // 
            this.toastPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.toastPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.toastPanel.Controls.Add(this.toastIconPb);
            this.toastPanel.Controls.Add(this.toastContextLbl);
            this.toastPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.toastPanel.Location = new System.Drawing.Point(0, 0);
            this.toastPanel.Name = "toastPanel";
            this.toastPanel.Size = new System.Drawing.Size(696, 91);
            this.toastPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.toastPanel.Style.BackColor1.Color = System.Drawing.Color.WhiteSmoke;
            this.toastPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.toastPanel.Style.Border = DevComponents.DotNetBar.eBorderType.Bump;
            this.toastPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.toastPanel.Style.BorderWidth = 3;
            this.toastPanel.Style.CornerDiameter = 10;
            this.toastPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.toastPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.toastPanel.Style.GradientAngle = 90;
            this.toastPanel.TabIndex = 1;
            // 
            // toastIconPb
            // 
            this.toastIconPb.BackgroundImage = global::ProposalReportingSystem.Properties.Resources.success;
            this.toastIconPb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toastIconPb.Location = new System.Drawing.Point(603, 12);
            this.toastIconPb.Name = "toastIconPb";
            this.toastIconPb.Size = new System.Drawing.Size(69, 65);
            this.toastIconPb.TabIndex = 1;
            this.toastIconPb.TabStop = false;
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(708, 89);
            this.Controls.Add(this.toastPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Toast";
            this.Opacity = 0.7D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Toast";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.toastPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toastIconPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label toastContextLbl;
        private System.Windows.Forms.Timer timer;
        private DevComponents.DotNetBar.PanelEx toastPanel;
        private System.Windows.Forms.PictureBox toastIconPb;
    }
}