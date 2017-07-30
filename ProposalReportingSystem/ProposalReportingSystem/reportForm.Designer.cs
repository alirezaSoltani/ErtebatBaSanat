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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.detailPrintBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.reportHeaderGbx = new System.Windows.Forms.GroupBox();
            this.reportTitleTxtbx = new System.Windows.Forms.TextBox();
            this.detailExecutor2Lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            this.reportHeaderGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailPrintBtn
            // 
            this.detailPrintBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.detailPrintBtn.Location = new System.Drawing.Point(25, 661);
            this.detailPrintBtn.Margin = new System.Windows.Forms.Padding(4);
            this.detailPrintBtn.Name = "detailPrintBtn";
            this.detailPrintBtn.Size = new System.Drawing.Size(307, 44);
            this.detailPrintBtn.TabIndex = 1;
            this.detailPrintBtn.Text = "پرینت خروجی";
            this.detailPrintBtn.UseVisualStyleBackColor = true;
            this.detailPrintBtn.Click += new System.EventHandler(this.detailPrintBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(339, 661);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(307, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "خروج";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // reportDataGridView
            // 
            this.reportDataGridView.AllowUserToAddRows = false;
            this.reportDataGridView.AllowUserToDeleteRows = false;
            this.reportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reportDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.reportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.reportDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.reportDataGridView.Location = new System.Drawing.Point(25, 132);
            this.reportDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.reportDataGridView.MultiSelect = false;
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.ReadOnly = true;
            this.reportDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.reportDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(226)))), ((int)(((byte)(171)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.reportDataGridView.RowTemplate.Height = 24;
            this.reportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportDataGridView.Size = new System.Drawing.Size(1265, 521);
            this.reportDataGridView.TabIndex = 3;
            // 
            // reportHeaderGbx
            // 
            this.reportHeaderGbx.Controls.Add(this.detailExecutor2Lbl);
            this.reportHeaderGbx.Controls.Add(this.reportTitleTxtbx);
            this.reportHeaderGbx.Font = new System.Drawing.Font("B Yekan+", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reportHeaderGbx.Location = new System.Drawing.Point(25, 12);
            this.reportHeaderGbx.Name = "reportHeaderGbx";
            this.reportHeaderGbx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportHeaderGbx.Size = new System.Drawing.Size(1265, 99);
            this.reportHeaderGbx.TabIndex = 4;
            this.reportHeaderGbx.TabStop = false;
            // 
            // reportTitleTxtbx
            // 
            this.reportTitleTxtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reportTitleTxtbx.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reportTitleTxtbx.Location = new System.Drawing.Point(19, 24);
            this.reportTitleTxtbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportTitleTxtbx.MaxLength = 100;
            this.reportTitleTxtbx.Multiline = true;
            this.reportTitleTxtbx.Name = "reportTitleTxtbx";
            this.reportTitleTxtbx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportTitleTxtbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportTitleTxtbx.Size = new System.Drawing.Size(1034, 58);
            this.reportTitleTxtbx.TabIndex = 12;
            // 
            // detailExecutor2Lbl
            // 
            this.detailExecutor2Lbl.BackColor = System.Drawing.Color.Transparent;
            this.detailExecutor2Lbl.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailExecutor2Lbl.Location = new System.Drawing.Point(1059, 38);
            this.detailExecutor2Lbl.Name = "detailExecutor2Lbl";
            this.detailExecutor2Lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.detailExecutor2Lbl.Size = new System.Drawing.Size(186, 29);
            this.detailExecutor2Lbl.TabIndex = 13;
            this.detailExecutor2Lbl.Text = "عنوان فهرست جستجو شده";
            this.detailExecutor2Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(209)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1319, 721);
            this.Controls.Add(this.reportHeaderGbx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.detailPrintBtn);
            this.Controls.Add(this.reportDataGridView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "reportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reportForm";
            this.Load += new System.EventHandler(this.reportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            this.reportHeaderGbx.ResumeLayout(false);
            this.reportHeaderGbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button detailPrintBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource reportBindingSource;
        private System.Windows.Forms.DataGridView reportDataGridView;
        private System.Windows.Forms.GroupBox reportHeaderGbx;
        private System.Windows.Forms.TextBox reportTitleTxtbx;
        private System.Windows.Forms.Label detailExecutor2Lbl;
    }
}