using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;


namespace FarsiCalendarComponent
{
    public delegate void FarsiCalendarEventHandler(object sender);

    /// <summary>
    /// Shows persian calendar
    /// </summary>
    public partial class FarsiCalendarControl : Control
    {
        private static FarsiDate selectedFarsiDate = new FarsiDate();

        public event FarsiCalendarEventHandler DateChanged;
        public event FarsiCalendarEventHandler SelectDay;

        public FarsiCalendarControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            selectedFarsiDate.DateChanged += new FarsiDateEventHandler(FarsiDate_DateChanged);
        }

        public DateTime SelectedGeoValue
        {
            get { 
                return selectedFarsiDate.GeoDate;
            }
            set { 
                selectedFarsiDate.GeoDate = value;
            }
        }

        public FarsiDate SelectedFarsiValue
        {
            get { 
                return selectedFarsiDate;
            }
            set {
                FarsiDate fd = new FarsiDate();
                    selectedFarsiDate.CopyEventHandler(fd);
                    selectedFarsiDate = value;
                    fd.CopyEventHandler(selectedFarsiDate);
                    Invalidate();
            }
        }

        private void FarsiDate_DateChanged()
        {
            SetMonthYear();
            Invalidate();

            if (DateChanged != null)
                DateChanged(this);
        }

        protected override void OnCreateControl()
        {
            InitializeMonthYearEditor();
            InitializeButtons();
            if (ShowToday)
            {
                SelectedGeoValue = DateTime.Now;
            }
            base.OnCreateControl();
        }

        private void InitializeMonthYearEditor()
        {
            numericUpDownYear.Width = 50;
            comboBoxMonth.Width = 70;
            int totalWidth = numericUpDownYear.Width + comboBoxMonth.Width;
            // numeric
            numericUpDownYear.Maximum = selectedFarsiDate.MaxYear;
            numericUpDownYear.Minimum = selectedFarsiDate.MinYear;
            numericUpDownYear.Top = (int)CY / 2 - numericUpDownYear.Height / 2;
            numericUpDownYear.Left = (int)Width / 2 - totalWidth / 2;
            numericUpDownYear.Visible = true;
            numericUpDownYear.Parent = this;
            // combobox
            comboBoxMonth.Top = (int)CY / 2 - comboBoxMonth.Height / 2;
            comboBoxMonth.Left = (int)Width / 2 - totalWidth / 2 + numericUpDownYear.Width + 1;
            comboBoxMonth.Visible = true;
            comboBoxMonth.Parent = this;
            SetMonthYear();
        }


        private void SetMonthYear()
        {
            numericUpDownYear.Value = selectedFarsiDate.Year;
            comboBoxMonth.SelectedIndex = selectedFarsiDate.Month - 1;
        }

        private void InitializeButtons()
        {
            buttonNextMonth.Parent = this;
            buttonPrevMonth.Parent = this;
            buttonPrevMonth.Top = 5;
            buttonPrevMonth.Height = (int)CY - 10;
            buttonPrevMonth.Left = Width - buttonNextMonth.Width - 5;
            buttonNextMonth.Top = 5;
            buttonNextMonth.Height = (int)CY - 10;
            buttonNextMonth.Left = 5;
        }


        private bool _ShowToday = true;
        public bool ShowToday
        {
            get { return _ShowToday; }
            set { _ShowToday = value; }
        }


        private Color _GridColor = Color.FromArgb(236, 233, 216);
        public Color GridColor
        {
            get { return _GridColor; }
            set { _GridColor = value; }
        }

        private Color _BorderColor = Color.FromArgb(0, 0, 0);
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }
        
        private Color _NumbersColor = Color.FromArgb(0, 0, 0);
        public Color NumbersColor
        {
            get { return _NumbersColor; }
            set { _NumbersColor = value; }
        }

        private Color _DaysBackColor = Color.FromArgb(204, 199, 186);
        public Color DaysBackColor
        {
            get { return _DaysBackColor; }
            set { _DaysBackColor = value; }
        }

        private Color _HeaderBackColor = Color.FromArgb(50, 50, 240);
        public Color HeaderBackColor
        {
            get { return _HeaderBackColor; }
            set { _HeaderBackColor = value; }
        }

        private Color _TodayNumberColor = Color.FromArgb(250, 0, 0);
        public Color TodayNumberColor
        {
            get { return _TodayNumberColor; }
            set { _TodayNumberColor = value; }
        }

        private Color _TodayBorderColor = Color.FromArgb(250, 200, 150);
        public Color TodayBorderColor
        {
            get { return _TodayBorderColor; }
            set { _TodayBorderColor = value; }
        }

        private Color _SelectedNumberColor = Color.FromArgb(0, 0, 250);
        public Color SelectedNumberColor 
        {
            get { return _SelectedNumberColor; }
            set { _SelectedNumberColor = value; }
        }

        private Color _SelectedBackColor = Color.FromArgb(170, 170, 250);
        public Color SelectedBackColor
        {
            get { return _SelectedBackColor; }
            set { _SelectedBackColor = value; }
        }

        private bool _VerticalGridLines = true;
        public bool VerticalGridLines
        {
            get { return _VerticalGridLines; }
            set { _VerticalGridLines = value; }
        }

        private bool _HorizontalGridLines = true;
        public bool HorizontalGridLines
        {
            get { return _HorizontalGridLines; }
            set { _HorizontalGridLines = value; }
        }

        private bool _ShowSmallDayName = false;
        public bool ShowSmallDayName
        {
            get { return _ShowSmallDayName; }
            set { _ShowSmallDayName = value; }
        }

        private bool _AntiAliasTexts = true;
        public bool AntiAliasTexts
        {
            get { return _AntiAliasTexts; }
            set { _AntiAliasTexts = value; }
        }

        protected void drawBorder(Graphics g)
        {
            using (Pen pen = new Pen(BorderColor))
            {
                g.DrawRectangle(pen, 0, 0, Width-1, Height-1);
            }
        }

        // Width of each cell
        protected float CX
        {
            get { return (Width) / 7; }
        }

        // Height of each cell
        protected float CY
        {
            get { return (Height) / 8; } // Two rows more, one for header & one for days name
        }

        protected void drawGrid(Graphics g)
        {
            // Fill days background
            using (SolidBrush brush = new SolidBrush(DaysBackColor))
            {
                g.FillRectangle(brush,
                    new Rectangle(1, (int)CY, Width - 2, (int)CY));
            }
            if (VerticalGridLines)
            {
                // Draw vertical grids
                using (Pen pen = new Pen(GridColor))
                {
                    for (int x = 1; x <= 6; x++)
                    {
                        g.DrawLine(pen, x * CX, CY + 1, x * CX, Height - 2);
                    }
                }
            }
            if (HorizontalGridLines)
            {
                using (Pen borderpen = new Pen(BorderColor))
                {
                    g.DrawLine(borderpen, 1, 2 * CY, Width - 2, 2 * CY);
                }
                using (Pen gridpen = new Pen(GridColor))
                {
                    for (int y = 3; y <= 7; y++)
                    {
                        g.DrawLine(gridpen, 1, y * CY, Width - 2, y * CY);
                    }
                }
            }
            // Fill header background
            using (SolidBrush headerbrush = new SolidBrush(HeaderBackColor))
            {
                g.FillRectangle(headerbrush,
                    new Rectangle(1, 1, Width-2, (int)CY));
            }
        }

        private string IntToFarsiStr(int num)
        {
            string str = "";
            do
            {
                int i = num % 10;
                str = (char)(i + 0x660) + str;
                num /= 10;
            }
            while (num != 0);
            return str;
        }

        private string[] DayName = new string[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" };
        private string[] SmallDayName = new string[] { "ش", "ی", "د", "س", "چ", "پ", "ج" };

        private void drawDaysName(Graphics g)
        {
            RectangleF rc = new RectangleF(0, CY, CX, CY);
            
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            using (SolidBrush numberbrush = new SolidBrush(NumbersColor))
            {
                for (int i = 0; i < 7; i++)
                {
                    rc.X = i * CX;
                    string dn = ShowSmallDayName ? SmallDayName[6 - i] : DayName[6 - i];
                    g.DrawString(dn, this.Font, numberbrush, rc, sf);
                }
            }
        }

        private void drawNumbers(Graphics g)
        {
            RectangleF rc = new RectangleF(0, 0, CX - 1, CY - 1);
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            int dayNumber = selectedFarsiDate.DaysInPrevMonth - selectedFarsiDate.FirstDayOfMonth;
            int monthPos = 0;   // 0: Prev month, 1: Cur Month, 2: Next Month
            for (int i = 0; i < 42; i++)
            {
                int y = i/7;
                int x = 6 - i % 7;  // Right to left
                rc.X = x * CX + 1;
                rc.Y = y * CY + (CY*2) + 1;
                // Increase number of the day and then show it
                dayNumber++;
                switch (monthPos)
                {
                    case 0:
                        if (dayNumber > selectedFarsiDate.DaysInPrevMonth)
                        {
                            // Start of first day of this month
                            dayNumber = 1;
                            // Now we are in current month
                            monthPos = 1;
                        }
                        break;
                    case 1:
                        if (dayNumber > selectedFarsiDate.DaysInMonth)
                        {
                            // Start of first day of NEXT month
                            dayNumber = 1;
                            // Now again we are not in current month
                            monthPos = 2;
                        }
                        break;
                }
                // Set the color of numbers
                SolidBrush brush;
                // Check for today
                if (monthPos == 1 && (new FarsiDate(selectedFarsiDate.Year,
                    selectedFarsiDate.Month, dayNumber)
                    == selectedFarsiDate))
                {
                    brush = new SolidBrush(SelectedNumberColor);
                    using (SolidBrush selback = new SolidBrush(SelectedBackColor))
                    {
                        g.FillRectangle(selback,
                            rc);
                    }
                }
                else if (FarsiDate.IsToday(selectedFarsiDate.Year,
                    selectedFarsiDate.Month, dayNumber) && monthPos == 1)
                {
                    brush = new SolidBrush(TodayNumberColor);
                }
                else
                {
                    brush =
                        monthPos == 1 ? (new SolidBrush(NumbersColor)) : (new SolidBrush(Color.FromArgb(100, NumbersColor)));
                }

                // For today
                if (FarsiDate.IsToday(selectedFarsiDate.Year,
                                    selectedFarsiDate.Month, dayNumber) && monthPos == 1)
                {
                    using (Pen todayborder = new Pen(TodayBorderColor))
                    {
                        g.DrawRectangle(todayborder,
                        rc.X, rc.Y, rc.Width - 1, rc.Height - 1);
                    }
                }

                g.DrawString(IntToFarsiStr(dayNumber), this.Font, brush, rc, sf);
                
                brush.Dispose();
            }
        }

        protected void DrawCalendar(Graphics g)
        {
            if (AntiAliasTexts)
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            }
            else
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            }
            drawGrid(g);
            drawDaysName(g);
            drawNumbers(g);
            drawBorder(g);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            DrawCalendar(pe.Graphics);
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        private void FarsiCalendarControl_SizeChanged(object sender, EventArgs e)
        {
            int totalWidth = numericUpDownYear.Width + comboBoxMonth.Width;
            // numericUpDown Control
            numericUpDownYear.Top = (int)CY / 2 - numericUpDownYear.Height / 2;
            numericUpDownYear.Left = (int)Width / 2 - totalWidth / 2;
            // combobox
            comboBoxMonth.Top = (int)CY / 2 - comboBoxMonth.Height / 2;
            comboBoxMonth.Left = (int)Width / 2 - totalWidth / 2 + numericUpDownYear.Width + 1;
            // Buttons
            buttonPrevMonth.Height = (int)CY - 10;
            buttonPrevMonth.Left = Width - buttonNextMonth.Width - 5;
            buttonNextMonth.Height = (int)CY - 10;

            this.Refresh();
        }

        private void buttonNextMonth_Click(object sender, EventArgs e)
        {
            selectedFarsiDate = selectedFarsiDate.AddMonth(1);
            SetMonthYear();
            //Invalidate();
        }

        private void buttonPrevMonth_Click(object sender, EventArgs e)
        {
            selectedFarsiDate = selectedFarsiDate.AddMonth(-1);
            SetMonthYear();
        }

        private void numericUpDownYear_ValueChanged(object sender, EventArgs e)
        {
            selectedFarsiDate.Year = (int)numericUpDownYear.Value;
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFarsiDate.Month = comboBoxMonth.SelectedIndex + 1;
            //Invalidate();
        }

        /// <summary>
        /// Get number of the day by its cell index
        /// </summary>
        /// <param name="cellIndex">Index of the cell</param>
        /// <param name="number">number of the day as output</param>
        /// <returns>
        /// 0: number = current month day number.
        /// 1: number = next month day number.
        /// -1: number = prev month day number.
        /// </returns>
        protected int GetCellIndexNumber(int cellIndex, out int number)
        {
            int fdm = selectedFarsiDate.FirstDayOfMonth;
            if (cellIndex + 1 <= fdm)
            {
                number = selectedFarsiDate.DaysInPrevMonth - (fdm - cellIndex) + 1;
                return -1;
            }
            if (cellIndex - fdm + 1 > selectedFarsiDate.DaysInMonth)
            {
                number = cellIndex - fdm - selectedFarsiDate.DaysInMonth + 1;
                return 1;
            }
            number = cellIndex - fdm + 1;
            return 0;
        }

        protected void SelectDateByPoint(Point pt)
        {
            int xCell = pt.X / (int)CX;
            int yCell = pt.Y / (int)CY;
            if (xCell >= 0 && xCell <= 6 &&
                yCell >= 2 && yCell <= 7)
            {
                int cellIndex = (6 - xCell) + (yCell - 2) * 7;
                // number of day
                int number;
                int ret = GetCellIndexNumber(cellIndex, out number);
                selectedFarsiDate = selectedFarsiDate.AddMonth(ret);
                selectedFarsiDate.Day = number;
                SetMonthYear();
                //Invalidate();
                if (SelectDay != null)
                {
                    SelectDay(this);
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectDateByPoint(e.Location);
                Focus();
            }

            base.OnMouseClick(e);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    selectedFarsiDate = selectedFarsiDate.AddDay(1);
                    break;
                case Keys.Right:
                    selectedFarsiDate = selectedFarsiDate.AddDay(-1);
                    break;
                case Keys.Up:
                    selectedFarsiDate = selectedFarsiDate.AddDay(-7);
                    break;
                case Keys.Down:
                    selectedFarsiDate = selectedFarsiDate.AddDay(7);
                    break;
                case Keys.PageDown:
                    selectedFarsiDate = selectedFarsiDate.AddMonth(1);
                    break;
                case Keys.PageUp:
                    selectedFarsiDate = selectedFarsiDate.AddMonth(-1);
                    break;
                case Keys.Enter:
                case Keys.Space:
                    if (SelectDay != null)
                    {
                        SelectDay(this);
                    }
                    break;
                default:
                    base.OnPreviewKeyDown(e);
                    return;
            }
            if (DateChanged != null)
                DateChanged(this);
            e.IsInputKey = true;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                selectedFarsiDate = selectedFarsiDate.AddMonth(-1);
                SetMonthYear();
                //Invalidate();
            }
            else if (e.Delta < 0)
            {
                selectedFarsiDate = selectedFarsiDate.AddMonth(1);
                SetMonthYear();
                //Invalidate();
            }
            base.OnMouseWheel(e);
        }

        private void toolStripMenuItemToday_Click(object sender, EventArgs e)
        {
            selectedFarsiDate = selectedFarsiDate.Today;
            SetMonthYear();
            Invalidate();
        }
    }
}
