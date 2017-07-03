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
            this.serverIPLbl = new System.Windows.Forms.Label();
            this.popUpPanel = new System.Windows.Forms.Panel();
            this.confirmBtn = new DevComponents.DotNetBar.ButtonX();
            this.popUpIconPbx = new System.Windows.Forms.PictureBox();
            this.serverIPTxtbx = new System.Windows.Forms.TextBox();
            this.cancelBtn = new DevComponents.DotNetBar.ButtonX();
            this.serverURLTxtbx = new System.Windows.Forms.TextBox();
            this.serverURLLbl = new System.Windows.Forms.Label();
            this.popUpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popUpIconPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // serverIPLbl
            // 
            this.serverIPLbl.BackColor = System.Drawing.Color.Transparent;
            this.serverIPLbl.Font = new System.Drawing.Font("B Yekan+", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.serverIPLbl.Location = new System.Drawing.Point(49, 43);
            this.serverIPLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serverIPLbl.Name = "serverIPLbl";
            this.serverIPLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.serverIPLbl.Size = new System.Drawing.Size(482, 26);
            this.serverIPLbl.TabIndex = 35;
            this.serverIPLbl.Text = "اطلاعات IP سرور را وارد کنید: ";
            // 
            // popUpPanel
            // 
            this.popUpPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(236)))), ((int)(((byte)(253)))));
            this.popUpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.popUpPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.popUpPanel.Controls.Add(this.serverURLTxtbx);
            this.popUpPanel.Controls.Add(this.serverURLLbl);
            this.popUpPanel.Controls.Add(this.cancelBtn);
            this.popUpPanel.Controls.Add(this.serverIPTxtbx);
            this.popUpPanel.Controls.Add(this.serverIPLbl);
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
            // serverIPTxtbx
            // 
            this.serverIPTxtbx.Location = new System.Drawing.Point(40, 72);
            this.serverIPTxtbx.Multiline = true;
            this.serverIPTxtbx.Name = "serverIPTxtbx";
            this.serverIPTxtbx.Size = new System.Drawing.Size(487, 49);
            this.serverIPTxtbx.TabIndex = 36;
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
            // serverURLTxtbx
            // 
            this.serverURLTxtbx.Location = new System.Drawing.Point(40, 153);
            this.serverURLTxtbx.Multiline = true;
            this.serverURLTxtbx.Name = "serverURLTxtbx";
            this.serverURLTxtbx.Size = new System.Drawing.Size(487, 49);
            this.serverURLTxtbx.TabIndex = 39;
            // 
            // serverURLLbl
            // 
            this.serverURLLbl.BackColor = System.Drawing.Color.Transparent;
            this.serverURLLbl.Font = new System.Drawing.Font("B Yekan+", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.serverURLLbl.Location = new System.Drawing.Point(49, 124);
            this.serverURLLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serverURLLbl.Name = "serverURLLbl";
            this.serverURLLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.serverURLLbl.Size = new System.Drawing.Size(482, 26);
            this.serverURLLbl.TabIndex = 38;
            this.serverURLLbl.Text = "اطلاعات URL سرور را وارد کنید: ";
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

        private System.Windows.Forms.Label serverIPLbl;
        private System.Windows.Forms.Panel popUpPanel;
        private System.Windows.Forms.PictureBox popUpIconPbx;
        private DevComponents.DotNetBar.ButtonX confirmBtn;
        private DevComponents.DotNetBar.ButtonX cancelBtn;
        private System.Windows.Forms.TextBox serverIPTxtbx;
        private System.Windows.Forms.TextBox serverURLTxtbx;
        private System.Windows.Forms.Label serverURLLbl;
    }
}