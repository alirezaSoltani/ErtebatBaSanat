namespace FarsiCalendarComponent
{
    partial class FarsiCalendarControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FarsiCalendarControl));
            this.numericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.buttonPrevMonth = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemToday = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNextMonth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).BeginInit();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownYear
            // 
            resources.ApplyResources(this.numericUpDownYear, "numericUpDownYear");
            this.numericUpDownYear.Maximum = new decimal(new int[] {
            1400,
            0,
            0,
            0});
            this.numericUpDownYear.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownYear.Name = "numericUpDownYear";
            this.numericUpDownYear.TabStop = false;
            this.numericUpDownYear.Value = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownYear.ValueChanged += new System.EventHandler(this.numericUpDownYear_ValueChanged);
            // 
            // buttonPrevMonth
            // 
            this.buttonPrevMonth.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.buttonPrevMonth, "buttonPrevMonth");
            this.buttonPrevMonth.ImageList = this.imageList1;
            this.buttonPrevMonth.Name = "buttonPrevMonth";
            this.buttonPrevMonth.TabStop = false;
            this.buttonPrevMonth.UseVisualStyleBackColor = true;
            this.buttonPrevMonth.Click += new System.EventHandler(this.buttonPrevMonth_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "next.bmp");
            this.imageList1.Images.SetKeyName(1, "prev.bmp");
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            resources.GetString("comboBoxMonth.Items"),
            resources.GetString("comboBoxMonth.Items1"),
            resources.GetString("comboBoxMonth.Items2"),
            resources.GetString("comboBoxMonth.Items3"),
            resources.GetString("comboBoxMonth.Items4"),
            resources.GetString("comboBoxMonth.Items5"),
            resources.GetString("comboBoxMonth.Items6"),
            resources.GetString("comboBoxMonth.Items7"),
            resources.GetString("comboBoxMonth.Items8"),
            resources.GetString("comboBoxMonth.Items9"),
            resources.GetString("comboBoxMonth.Items10"),
            resources.GetString("comboBoxMonth.Items11")});
            resources.ApplyResources(this.comboBoxMonth, "comboBoxMonth");
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.TabStop = false;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemToday});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            resources.ApplyResources(this.contextMenuStripMain, "contextMenuStripMain");
            // 
            // toolStripMenuItemToday
            // 
            this.toolStripMenuItemToday.Name = "toolStripMenuItemToday";
            resources.ApplyResources(this.toolStripMenuItemToday, "toolStripMenuItemToday");
            this.toolStripMenuItemToday.Click += new System.EventHandler(this.toolStripMenuItemToday_Click);
            // 
            // buttonNextMonth
            // 
            resources.ApplyResources(this.buttonNextMonth, "buttonNextMonth");
            this.buttonNextMonth.ImageList = this.imageList1;
            this.buttonNextMonth.Name = "buttonNextMonth";
            this.buttonNextMonth.TabStop = false;
            this.buttonNextMonth.UseVisualStyleBackColor = true;
            this.buttonNextMonth.Click += new System.EventHandler(this.buttonNextMonth_Click);
            // 
            // FarsiCalendarControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.contextMenuStripMain;
            this.SizeChanged += new System.EventHandler(this.FarsiCalendarControl_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).EndInit();
            this.contextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownYear;
        private System.Windows.Forms.Button buttonPrevMonth;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemToday;
        private System.Windows.Forms.Button buttonNextMonth;
        private System.Windows.Forms.ImageList imageList1;

    }
}
