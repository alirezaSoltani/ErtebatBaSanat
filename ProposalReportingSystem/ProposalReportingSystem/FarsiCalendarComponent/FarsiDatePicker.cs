using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FarsiCalendarComponent
{
    public partial class FarsiDatePicker : UserControl
    {
        private CalendarForm calendarForm = new CalendarForm();

        public FarsiCalendarComponent.FarsiCalendarControl CalendarControl
        {
            get
            {
                return calendarForm.farsiCalendarControl;
            }
        }

        [Category("Behavior"), Browsable(true), Bindable(true)]
        public DateTime? GeoDate
        {
            get
            {
                // Get Date from masked EditBox insted of Calendar Control
                FarsiCalendarComponent.FarsiDate fd = new FarsiCalendarComponent.FarsiDate();
                try
                {
                    fd.FarsiDateValue = defaultMaskedTextBox.Text;
                    return fd.GeoDate;
                }
                catch
                {
                    try
                    {
                        // If it's not possible get it from calendar
                        return CalendarControl.SelectedGeoValue;
                    }
                    catch
                    {
                        // If none of them are posible return today
                        return (DateTime?)DateTime.Today;
                    }
                }
            }
            set
            {
                if (value == null)
                {
                    CalendarControl.SelectedGeoValue = DateTime.Today;
                }
                else
                {
                    CalendarControl.SelectedGeoValue = (DateTime)value;
                }
                defaultMaskedTextBox.Text = CalendarControl.SelectedFarsiValue.FarsiDateValue;
            }
        }

        public FarsiDatePicker()
        {
            InitializeComponent();
            // Create Calendar
            calendarForm.CreateControl();
            calendarForm.Deactivate += new EventHandler(calendarForm_Deactivate);
            CalendarControl.Visible = true;
            CalendarControl.KeyDown += new KeyEventHandler(CalendarControl_KeyDown);
            CalendarControl.SelectDay += new FarsiCalendarComponent.FarsiCalendarEventHandler(CalendarControl_SelectDay);
            // Set Date
            defaultMaskedTextBox.Text = CalendarControl.SelectedFarsiValue.FarsiDateValue;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '/' || e.KeyChar == '-')
            {
                string txt = defaultMaskedTextBox.Text;
                int start = defaultMaskedTextBox.SelectionStart;
                start = start / 3;
                switch (start)
                {
                    case 0:
                        string num = txt.Substring(0, 2).Trim(defaultMaskedTextBox.PromptChar);
                        if (num.Length == 0)
                        {
                            FarsiCalendarComponent.FarsiDate fdate = new FarsiCalendarComponent.FarsiDate();
                            num = fdate.TwoDigitYear.ToString("D2");
                        }
                        else if (num.Length == 1)
                        {
                            num = "0" + num;
                        }
                        txt = num + txt.Substring(2);
                        break;
                    case 1:
                        num = txt.Substring(3, 2).Trim(defaultMaskedTextBox.PromptChar);
                        if (num.Length == 0)
                            num = "01";
                        else if (num.Length == 1)
                        {
                            num = "0" + num;
                        }
                        txt = txt.Substring(0, 3) + num + txt.Substring(5);
                        break;
                    case 2:
                        num = txt.Substring(6, 2).Trim(defaultMaskedTextBox.PromptChar);
                        if (num.Length == 0)
                            num = "01";
                        else if (num.Length == 1)
                        {
                            num = "0" + num;
                        }
                        txt = txt.Substring(0, 6) + num;
                        break;
                }
                defaultMaskedTextBox.Text = txt;
                defaultMaskedTextBox.SelectionStart = (start * 3) + 3;
                e.Handled = true;

            }
            // User changed the date value
            OnValueChangedByUser();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetDropButtonLocation();
            base.OnSizeChanged(e);
        }

        private void FarsiDatePicker_Load(object sender, EventArgs e)
        {
            SetDropButtonLocation();
        }

        private void SetDropButtonLocation()
        {
            DropButton.Top = defaultMaskedTextBox.Top + 1;
            DropButton.Height = defaultMaskedTextBox.Height - 2;
            DropButton.Width = 20;
            if (RightToLeft == RightToLeft.Yes)
            {
                DropButton.Left = defaultMaskedTextBox.Left + 1;
            }
            else
            {
                DropButton.Left = defaultMaskedTextBox.Right - DropButton.Width - 1;
            }
        }

        private void DropButton_Click(object sender, EventArgs e)
        {
            if (!calendarForm.IsHandleCreated)
            {
                SetCalendarLocation();
                calendarForm.Visible = true;
                CalendarControl.Focus();
                SetCalendarControlDate();
                CalendarControl.Invalidate();
            }
            else
            {
                if (CalendarControl.Visible)
                {
                    calendarForm.Hide();
                }
                else
                {
                    // Set Date
                    SetCalendarControlDate();
                    SetCalendarLocation();
                    calendarForm.Visible = true;
                    CalendarControl.Focus();
                }
            }
        }

        private void SetCalendarControlDate()
        {
            try
            {
                CalendarControl.SelectedFarsiValue.FarsiDateValue = defaultMaskedTextBox.Text;
            }
            catch
            {
                CalendarControl.SelectedFarsiValue.GeoDate = DateTime.Today;
            }
        }

        void CalendarControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                calendarForm_Deactivate(this, new EventArgs());
            }
        }

        void calendarForm_Deactivate(object sender, EventArgs e)
        {
            this.ParentForm.Activate();
            calendarForm.Hide();
            
        }

        private void SetCalendarLocation()
        {
            Point point = defaultMaskedTextBox.PointToScreen(new Point(defaultMaskedTextBox.Left, defaultMaskedTextBox.Bottom));
            calendarForm.Top = point.Y;
            calendarForm.Left = point.X;
        }

        void CalendarControl_SelectDay(object sender)
        {
            defaultMaskedTextBox.Text = CalendarControl.SelectedFarsiValue.FarsiDateValue;
            calendarForm.Hide();
            defaultMaskedTextBox.Focus();

            OnValueChangedByUser();
        }

        private void FarsiDatePicker_Resize(object sender, EventArgs e)
        {
            SetDropButtonLocation();
        }

        public void SelectAll()
        {
            defaultMaskedTextBox.SelectAll();
        }

        private void defaultMaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                DropButton_Click(this, e);
            }
        }

        public virtual void OnValueChangedByUser()
        {
        }

    }
}
