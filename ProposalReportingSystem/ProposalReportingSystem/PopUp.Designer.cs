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
            this.popUpContextLbl = new System.Windows.Forms.Label();
            this.popUpIconPbx = new System.Windows.Forms.PictureBox();
            this.popUpCancelBtn = new DevComponents.DotNetBar.ButtonX();
            this.popUpConfirmBtn = new DevComponents.DotNetBar.ButtonX();
            this.popUpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popUpIconPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // popUpPanel
            // 
            this.popUpPanel.BackgroundImage = global::ProposalReportingSystem.Properties.Resources.login3;
            this.popUpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.popUpPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.popUpPanel.Controls.Add(this.popUpContextLbl);
            this.popUpPanel.Controls.Add(this.popUpIconPbx);
            this.popUpPanel.Controls.Add(this.popUpCancelBtn);
            this.popUpPanel.Controls.Add(this.popUpConfirmBtn);
            this.popUpPanel.Location = new System.Drawing.Point(1, -1);
            this.popUpPanel.Name = "popUpPanel";
            this.popUpPanel.Size = new System.Drawing.Size(644, 231);
            this.popUpPanel.TabIndex = 0;
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
            // popUpCancelBtn
            // 
            this.popUpCancelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.popUpCancelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.popUpCancelBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.popUpCancelBtn.Location = new System.Drawing.Point(158, 186);
            this.popUpCancelBtn.Name = "popUpCancelBtn";
            this.popUpCancelBtn.Size = new System.Drawing.Size(126, 29);
            this.popUpCancelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.popUpCancelBtn.TabIndex = 33;
            this.popUpCancelBtn.Text = "لغو";
            this.popUpCancelBtn.Click += new System.EventHandler(this.popUpCancelBtn_Click);
            // 
            // popUpConfirmBtn
            // 
            this.popUpConfirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.popUpConfirmBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.popUpConfirmBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.popUpConfirmBtn.Location = new System.Drawing.Point(26, 186);
            this.popUpConfirmBtn.Name = "popUpConfirmBtn";
            this.popUpConfirmBtn.Size = new System.Drawing.Size(126, 29);
            this.popUpConfirmBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.popUpConfirmBtn.TabIndex = 32;
            this.popUpConfirmBtn.Text = "تایید";
            this.popUpConfirmBtn.Click += new System.EventHandler(this.popUpConfirmBtn_Click);
            // 
            // PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 228);
            this.Controls.Add(this.popUpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PopUp";
            this.Text = "اطلاعات";
            this.popUpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popUpIconPbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel popUpPanel;
        private System.Windows.Forms.PictureBox popUpIconPbx;
        private DevComponents.DotNetBar.ButtonX popUpCancelBtn;
        private DevComponents.DotNetBar.ButtonX popUpConfirmBtn;
        private System.Windows.Forms.Label popUpContextLbl;
    }
}