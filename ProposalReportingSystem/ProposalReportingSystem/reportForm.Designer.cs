namespace ProposalReportingSystem
{
    partial class reportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.reportHeaderGbx = new System.Windows.Forms.GroupBox();
            this.reportTitleLbl = new System.Windows.Forms.Label();
            this.reportTitleTxtbx = new System.Windows.Forms.TextBox();
            this.reportExitBtn = new DevComponents.DotNetBar.ButtonX();
            this.reportPreviewBtn = new DevComponents.DotNetBar.ButtonX();
            this.reportFastPrintBtn = new DevComponents.DotNetBar.ButtonX();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            this.reportHeaderGbx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportDataGridView
            // 
            this.reportDataGridView.AllowUserToAddRows = false;
            this.reportDataGridView.AllowUserToDeleteRows = false;
            this.reportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reportDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.reportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.reportDataGridView.DefaultCellStyle = dataGridViewCellStyle18;
            this.reportDataGridView.Location = new System.Drawing.Point(25, 132);
            this.reportDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.reportDataGridView.MultiSelect = false;
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.ReadOnly = true;
            this.reportDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.NullValue = null;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.reportDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(226)))), ((int)(((byte)(171)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.reportDataGridView.RowTemplate.Height = 24;
            this.reportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportDataGridView.Size = new System.Drawing.Size(1265, 483);
            this.reportDataGridView.TabIndex = 3;
            this.reportDataGridView.TabStop = false;
            // 
            // reportHeaderGbx
            // 
            this.reportHeaderGbx.Controls.Add(this.reportTitleLbl);
            this.reportHeaderGbx.Controls.Add(this.reportTitleTxtbx);
            this.reportHeaderGbx.Font = new System.Drawing.Font("B Yekan+", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reportHeaderGbx.Location = new System.Drawing.Point(25, 12);
            this.reportHeaderGbx.Name = "reportHeaderGbx";
            this.reportHeaderGbx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportHeaderGbx.Size = new System.Drawing.Size(1265, 99);
            this.reportHeaderGbx.TabIndex = 4;
            this.reportHeaderGbx.TabStop = false;
            // 
            // reportTitleLbl
            // 
            this.reportTitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.reportTitleLbl.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportTitleLbl.Location = new System.Drawing.Point(1140, 38);
            this.reportTitleLbl.Name = "reportTitleLbl";
            this.reportTitleLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportTitleLbl.Size = new System.Drawing.Size(105, 29);
            this.reportTitleLbl.TabIndex = 13;
            this.reportTitleLbl.Text = "عنوان ریپورت";
            this.reportTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reportTitleTxtbx
            // 
            this.reportTitleTxtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reportTitleTxtbx.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reportTitleTxtbx.Location = new System.Drawing.Point(19, 24);
            this.reportTitleTxtbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportTitleTxtbx.MaxLength = 180;
            this.reportTitleTxtbx.Multiline = true;
            this.reportTitleTxtbx.Name = "reportTitleTxtbx";
            this.reportTitleTxtbx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportTitleTxtbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportTitleTxtbx.Size = new System.Drawing.Size(1096, 58);
            this.reportTitleTxtbx.TabIndex = 12;
            // 
            // reportExitBtn
            // 
            this.reportExitBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.reportExitBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.reportExitBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reportExitBtn.Image = global::ProposalReportingSystem.Properties.Resources.logout;
            this.reportExitBtn.ImageTextSpacing = 7;
            this.reportExitBtn.Location = new System.Drawing.Point(25, 625);
            this.reportExitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportExitBtn.Name = "reportExitBtn";
            this.reportExitBtn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.reportExitBtn.Size = new System.Drawing.Size(230, 44);
            this.reportExitBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.reportExitBtn.TabIndex = 14;
            this.reportExitBtn.Text = "خروج";
            this.reportExitBtn.Click += new System.EventHandler(this.reportExitBtn_Click_1);
            // 
            // reportPreviewBtn
            // 
            this.reportPreviewBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.reportPreviewBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.reportPreviewBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reportPreviewBtn.Image = global::ProposalReportingSystem.Properties.Resources.preview;
            this.reportPreviewBtn.ImageTextSpacing = 7;
            this.reportPreviewBtn.Location = new System.Drawing.Point(272, 625);
            this.reportPreviewBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportPreviewBtn.Name = "reportPreviewBtn";
            this.reportPreviewBtn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.reportPreviewBtn.Size = new System.Drawing.Size(230, 44);
            this.reportPreviewBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.reportPreviewBtn.TabIndex = 13;
            this.reportPreviewBtn.Text = "پیش نمایش ریپورت";
            this.reportPreviewBtn.Click += new System.EventHandler(this.reportPreviewBtn_Click);
            // 
            // reportFastPrintBtn
            // 
            this.reportFastPrintBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.reportFastPrintBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.reportFastPrintBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reportFastPrintBtn.Image = global::ProposalReportingSystem.Properties.Resources.printer;
            this.reportFastPrintBtn.ImageTextSpacing = 7;
            this.reportFastPrintBtn.Location = new System.Drawing.Point(518, 625);
            this.reportFastPrintBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportFastPrintBtn.Name = "reportFastPrintBtn";
            this.reportFastPrintBtn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.reportFastPrintBtn.Size = new System.Drawing.Size(230, 44);
            this.reportFastPrintBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.reportFastPrintBtn.TabIndex = 12;
            this.reportFastPrintBtn.Text = "پرینت ریپورت";
            this.reportFastPrintBtn.Click += new System.EventHandler(this.reportFastPrintBtn_Click);
            // 
            // reportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(209)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1319, 680);
            this.Controls.Add(this.reportExitBtn);
            this.Controls.Add(this.reportPreviewBtn);
            this.Controls.Add(this.reportFastPrintBtn);
            this.Controls.Add(this.reportHeaderGbx);
            this.Controls.Add(this.reportDataGridView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "reportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reportForm";
            this.Load += new System.EventHandler(this.reportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            this.reportHeaderGbx.ResumeLayout(false);
            this.reportHeaderGbx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource reportBindingSource;
        private System.Windows.Forms.DataGridView reportDataGridView;
        private System.Windows.Forms.GroupBox reportHeaderGbx;
        private System.Windows.Forms.TextBox reportTitleTxtbx;
        private System.Windows.Forms.Label reportTitleLbl;
        private DevComponents.DotNetBar.ButtonX reportFastPrintBtn;
        private DevComponents.DotNetBar.ButtonX reportPreviewBtn;
        private DevComponents.DotNetBar.ButtonX reportExitBtn;
    }
}