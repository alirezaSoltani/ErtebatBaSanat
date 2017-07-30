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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.detailPrintBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.reportHeaderGbx = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // detailPrintBtn
            // 
            this.detailPrintBtn.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.detailPrintBtn.Location = new System.Drawing.Point(15, 743);
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
            this.button1.Location = new System.Drawing.Point(329, 743);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.reportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.reportDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.reportDataGridView.Location = new System.Drawing.Point(25, 132);
            this.reportDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.reportDataGridView.MultiSelect = false;
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.ReadOnly = true;
            this.reportDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.NullValue = null;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.reportDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(226)))), ((int)(((byte)(171)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.reportDataGridView.RowTemplate.Height = 24;
            this.reportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportDataGridView.Size = new System.Drawing.Size(1265, 580);
            this.reportDataGridView.TabIndex = 3;
            // 
            // reportHeaderGbx
            // 
            this.reportHeaderGbx.Font = new System.Drawing.Font("B Yekan+", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reportHeaderGbx.Location = new System.Drawing.Point(25, 12);
            this.reportHeaderGbx.Name = "reportHeaderGbx";
            this.reportHeaderGbx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportHeaderGbx.Size = new System.Drawing.Size(1265, 100);
            this.reportHeaderGbx.TabIndex = 4;
            this.reportHeaderGbx.TabStop = false;
            // 
            // reportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(209)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1319, 802);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button detailPrintBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource reportBindingSource;
        private System.Windows.Forms.DataGridView reportDataGridView;
        private System.Windows.Forms.GroupBox reportHeaderGbx;
    }
}