namespace FarsiCalendarComponent
{
    partial class CalendarForm
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
            FarsiCalendarComponent.FarsiDate farsiDate1 = new FarsiCalendarComponent.FarsiDate();
            this.farsiCalendarControl = new FarsiCalendarComponent.FarsiCalendarControl();
            this.SuspendLayout();
            // 
            // farsiCalendarControl
            // 
            this.farsiCalendarControl.BackColor = System.Drawing.Color.White;
            this.farsiCalendarControl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.farsiCalendarControl.DaysBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(199)))), ((int)(((byte)(186)))));
            this.farsiCalendarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.farsiCalendarControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.farsiCalendarControl.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.farsiCalendarControl.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(240)))));
            this.farsiCalendarControl.HorizontalGridLines = true;
            this.farsiCalendarControl.Location = new System.Drawing.Point(0, 0);
            this.farsiCalendarControl.Name = "farsiCalendarControl";
            this.farsiCalendarControl.NumbersColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.farsiCalendarControl.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(250)))));
            this.farsiCalendarControl.SelectedFarsiValue = farsiDate1;
            this.farsiCalendarControl.SelectedNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(250)))));
            this.farsiCalendarControl.ShowSmallDayName = true;
            this.farsiCalendarControl.ShowToday = true;
            this.farsiCalendarControl.Size = new System.Drawing.Size(197, 200);
            this.farsiCalendarControl.TabIndex = 0;
            this.farsiCalendarControl.Text = "farsiCalendarControl1";
            this.farsiCalendarControl.TodayBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.farsiCalendarControl.TodayNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.farsiCalendarControl.VerticalGridLines = true;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 200);
            this.ControlBox = false;
            this.Controls.Add(this.farsiCalendarControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalendarForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CalendarForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public FarsiCalendarComponent.FarsiCalendarControl farsiCalendarControl;

    }
}