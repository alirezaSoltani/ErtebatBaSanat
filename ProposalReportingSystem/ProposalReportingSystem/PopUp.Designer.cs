namespace ProposalReportingSystem
{
    partial class PopUp
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
            this.popUpPanel = new System.Windows.Forms.Panel();
            this.popUpRightBtn = new DevComponents.DotNetBar.ButtonX();
            this.popUpContextLbl = new System.Windows.Forms.Label();
            this.popUpIconPbx = new System.Windows.Forms.PictureBox();
            this.popUpCenterBtn = new DevComponents.DotNetBar.ButtonX();
            this.popUpLeftBtn = new DevComponents.DotNetBar.ButtonX();
            this.popUpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popUpIconPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // popUpPanel
            // 
            this.popUpPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(236)))), ((int)(((byte)(253)))));
            this.popUpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.popUpPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.popUpPanel.Controls.Add(this.popUpRightBtn);
            this.popUpPanel.Controls.Add(this.popUpContextLbl);
            this.popUpPanel.Controls.Add(this.popUpIconPbx);
            this.popUpPanel.Controls.Add(this.popUpCenterBtn);
            this.popUpPanel.Controls.Add(this.popUpLeftBtn);
            this.popUpPanel.Location = new System.Drawing.Point(1, -1);
            this.popUpPanel.Name = "popUpPanel";
            this.popUpPanel.Size = new System.Drawing.Size(644, 231);
            this.popUpPanel.TabIndex = 0;
            // 
            // popUpRightBtn
            // 
            this.popUpRightBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.popUpRightBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.popUpRightBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.popUpRightBtn.Location = new System.Drawing.Point(290, 186);
            this.popUpRightBtn.Name = "popUpRightBtn";
            this.popUpRightBtn.Size = new System.Drawing.Size(126, 29);
            this.popUpRightBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.popUpRightBtn.TabIndex = 36;
            this.popUpRightBtn.Text = "لغو";
            this.popUpRightBtn.Click += new System.EventHandler(this.popUpRightBtn_Click);
            // 
            // popUpContextLbl
            // 
            this.popUpContextLbl.BackColor = System.Drawing.Color.Transparent;
            this.popUpContextLbl.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.popUpContextLbl.Location = new System.Drawing.Point(26, 49);
            this.popUpContextLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.popUpContextLbl.Name = "popUpContextLbl";
            this.popUpContextLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.popUpContextLbl.Size = new System.Drawing.Size(482, 112);
            this.popUpContextLbl.TabIndex = 35;
            this.popUpContextLbl.Text = "متن خطا در این بخش قرار میگیرد-متن خطا در این بخش قرار میگیرد-متن خطا در این بخش " +
    "قرار میگیرد-متن خطا در این بخش قرار میگیرد-متن خطا در این بخش قرار میگیرد-";
            // 
            // popUpIconPbx
            // 
            this.popUpIconPbx.BackColor = System.Drawing.Color.Transparent;
            this.popUpIconPbx.BackgroundImage = global::ProposalReportingSystem.Properties.Resources.success;
            this.popUpIconPbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.popUpIconPbx.Location = new System.Drawing.Point(525, 35);
            this.popUpIconPbx.Name = "popUpIconPbx";
            this.popUpIconPbx.Size = new System.Drawing.Size(64, 64);
            this.popUpIconPbx.TabIndex = 34;
            this.popUpIconPbx.TabStop = false;
            // 
            // popUpCenterBtn
            // 
            this.popUpCenterBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.popUpCenterBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.popUpCenterBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.popUpCenterBtn.Location = new System.Drawing.Point(158, 186);
            this.popUpCenterBtn.Name = "popUpCenterBtn";
            this.popUpCenterBtn.Size = new System.Drawing.Size(126, 29);
            this.popUpCenterBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.popUpCenterBtn.TabIndex = 33;
            this.popUpCenterBtn.Text = "خیر";
            this.popUpCenterBtn.Click += new System.EventHandler(this.popUpCenterBtn_Click);
            // 
            // popUpLeftBtn
            // 
            this.popUpLeftBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.popUpLeftBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.popUpLeftBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.popUpLeftBtn.Location = new System.Drawing.Point(26, 186);
            this.popUpLeftBtn.Name = "popUpLeftBtn";
            this.popUpLeftBtn.Size = new System.Drawing.Size(126, 29);
            this.popUpLeftBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.popUpLeftBtn.TabIndex = 32;
            this.popUpLeftBtn.Text = "بله";
            this.popUpLeftBtn.Click += new System.EventHandler(this.popUpLeftBtn_Click);
            // 
            // PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 228);
            this.Controls.Add(this.popUpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاعات";
            this.popUpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popUpIconPbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel popUpPanel;
        private System.Windows.Forms.PictureBox popUpIconPbx;
        private DevComponents.DotNetBar.ButtonX popUpCenterBtn;
        private DevComponents.DotNetBar.ButtonX popUpLeftBtn;
        private System.Windows.Forms.Label popUpContextLbl;
        private DevComponents.DotNetBar.ButtonX popUpRightBtn;
    }
}