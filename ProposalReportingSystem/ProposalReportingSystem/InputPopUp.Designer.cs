namespace ProposalReportingSystem
{
    partial class InputPopUp
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
            this.popUpContextLbl = new System.Windows.Forms.Label();
            this.popUpPanel = new System.Windows.Forms.Panel();
            this.confirmBtn = new DevComponents.DotNetBar.ButtonX();
            this.popUpIconPbx = new System.Windows.Forms.PictureBox();
            this.serverAdressTxtbx = new System.Windows.Forms.TextBox();
            this.cancelBtn = new DevComponents.DotNetBar.ButtonX();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.popUpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popUpIconPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // popUpContextLbl
            // 
            this.popUpContextLbl.BackColor = System.Drawing.Color.Transparent;
            this.popUpContextLbl.Font = new System.Drawing.Font("B Yekan+", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.popUpContextLbl.Location = new System.Drawing.Point(49, 43);
            this.popUpContextLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.popUpContextLbl.Name = "popUpContextLbl";
            this.popUpContextLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.popUpContextLbl.Size = new System.Drawing.Size(482, 26);
            this.popUpContextLbl.TabIndex = 35;
            this.popUpContextLbl.Text = "اطلاعات IP سرور را وارد کنید: ";
            // 
            // popUpPanel
            // 
            this.popUpPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(236)))), ((int)(((byte)(253)))));
            this.popUpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.popUpPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.popUpPanel.Controls.Add(this.textBox1);
            this.popUpPanel.Controls.Add(this.label1);
            this.popUpPanel.Controls.Add(this.cancelBtn);
            this.popUpPanel.Controls.Add(this.serverAdressTxtbx);
            this.popUpPanel.Controls.Add(this.popUpContextLbl);
            this.popUpPanel.Controls.Add(this.popUpIconPbx);
            this.popUpPanel.Controls.Add(this.confirmBtn);
            this.popUpPanel.Location = new System.Drawing.Point(-30, -10);
            this.popUpPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.popUpPanel.Name = "popUpPanel";
            this.popUpPanel.Size = new System.Drawing.Size(644, 274);
            this.popUpPanel.TabIndex = 1;
            // 
            // confirmBtn
            // 
            this.confirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.confirmBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.confirmBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.confirmBtn.Location = new System.Drawing.Point(40, 222);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(159, 34);
            this.confirmBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.confirmBtn.TabIndex = 32;
            this.confirmBtn.Text = "تایید";
            // 
            // popUpIconPbx
            // 
            this.popUpIconPbx.BackColor = System.Drawing.Color.Transparent;
            this.popUpIconPbx.BackgroundImage = global::ProposalReportingSystem.Properties.Resources.database;
            this.popUpIconPbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.popUpIconPbx.Location = new System.Drawing.Point(538, 21);
            this.popUpIconPbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.popUpIconPbx.Name = "popUpIconPbx";
            this.popUpIconPbx.Size = new System.Drawing.Size(64, 64);
            this.popUpIconPbx.TabIndex = 34;
            this.popUpIconPbx.TabStop = false;
            // 
            // serverAdressTxtbx
            // 
            this.serverAdressTxtbx.Location = new System.Drawing.Point(40, 72);
            this.serverAdressTxtbx.Multiline = true;
            this.serverAdressTxtbx.Name = "serverAdressTxtbx";
            this.serverAdressTxtbx.Size = new System.Drawing.Size(487, 49);
            this.serverAdressTxtbx.TabIndex = 36;
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cancelBtn.Location = new System.Drawing.Point(223, 222);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(159, 34);
            this.cancelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.cancelBtn.TabIndex = 37;
            this.cancelBtn.Text = "لغو";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 153);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(487, 49);
            this.textBox1.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Yekan+", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(49, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(482, 26);
            this.label1.TabIndex = 38;
            this.label1.Text = "اطلاعات URL سرور را وارد کنید: ";
            // 
            // InputPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 261);
            this.Controls.Add(this.popUpPanel);
            this.Name = "InputPopUp";
            this.Text = "آدرس سرور";
            this.popUpPanel.ResumeLayout(false);
            this.popUpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popUpIconPbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label popUpContextLbl;
        private System.Windows.Forms.Panel popUpPanel;
        private System.Windows.Forms.PictureBox popUpIconPbx;
        private DevComponents.DotNetBar.ButtonX confirmBtn;
        private DevComponents.DotNetBar.ButtonX cancelBtn;
        private System.Windows.Forms.TextBox serverAdressTxtbx;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}