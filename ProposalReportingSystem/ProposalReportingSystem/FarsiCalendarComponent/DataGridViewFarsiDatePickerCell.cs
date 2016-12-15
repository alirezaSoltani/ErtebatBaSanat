using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FarsiCalendarComponent
{
    public class DataGridViewFarsiDatePickerCell : DataGridViewCell
    {
        public DataGridViewFarsiDatePickerCell()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            FarsiDatePickerCellControl DatePicker = DataGridView.EditingControl as FarsiDatePickerCellControl;

            try
            {
                DatePicker.GeoDate = (DateTime)this.Value;
            }
            catch
            {
            }
        }

        public override void DetachEditingControl()
        {
            base.DetachEditingControl();

            FarsiDatePickerCellControl DatePicker = (FarsiDatePickerCellControl)(DataGridView.EditingControl);
            this.Value = DatePicker.GeoDate;
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
        {
            FarsiCalendarComponent.FarsiDate fd = new FarsiDate();
            fd.FarsiDateValue = (string)formattedValue;
            return fd.GeoDate;
        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }

        public override Type FormattedValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override Type EditType
        {
            get
            {
                return typeof(FarsiDatePickerCellControl);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return DateTime.Now;
            }
        }

        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Space)
                return true;
            return false;
        }

        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            base.OnClick(e);
            DataGridView.BeginEdit(true);
        }

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            Rectangle cellRect = new Rectangle(cellBounds.Location, new Size(cellBounds.Width - 1, cellBounds.Height - 1));
            Color textColor = cellStyle.ForeColor;
            if ((cellState & DataGridViewElementStates.Selected) != 0)
            {
                using (SolidBrush backbrush = new SolidBrush(cellStyle.SelectionBackColor))
                {
                    graphics.FillRectangle(backbrush, cellRect);
                }
                textColor = cellStyle.SelectionForeColor;
            }
            else
            {
                using (SolidBrush backbrush = new SolidBrush(cellStyle.BackColor))
                {
                    graphics.FillRectangle(backbrush, cellRect);
                }
                using (Pen backpen = new Pen(this.DataGridView.BackgroundColor))
                {
                    graphics.DrawRectangle(backpen, cellBounds.Left - 1, cellBounds.Top - 1, cellBounds.Width, cellBounds.Height);
                }
            }
            StringFormat strFormat = new StringFormat();
            // Set Alignment
            switch(cellStyle.Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    strFormat.LineAlignment = StringAlignment.Far;
                    strFormat.Alignment = StringAlignment.Center;
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                    strFormat.LineAlignment = StringAlignment.Far;
                    strFormat.Alignment = StringAlignment.Near;
                    break;
                case DataGridViewContentAlignment.BottomRight:
                    strFormat.LineAlignment = StringAlignment.Far;
                    strFormat.Alignment = StringAlignment.Far;
                    break;
                case DataGridViewContentAlignment.MiddleCenter:
                    strFormat.LineAlignment = StringAlignment.Center;
                    strFormat.Alignment = StringAlignment.Center;
                    break;
                case DataGridViewContentAlignment.MiddleLeft:
                    strFormat.LineAlignment = StringAlignment.Center;
                    strFormat.Alignment = StringAlignment.Near;
                    break;
                case DataGridViewContentAlignment.MiddleRight:
                    strFormat.LineAlignment = StringAlignment.Center;
                    strFormat.Alignment = StringAlignment.Far;
                    break;
                case DataGridViewContentAlignment.TopCenter:
                    strFormat.LineAlignment = StringAlignment.Near;
                    strFormat.Alignment = StringAlignment.Center;
                    break;
                case DataGridViewContentAlignment.TopLeft:
                    strFormat.LineAlignment = StringAlignment.Near;
                    strFormat.Alignment = StringAlignment.Near;
                    break;
                case DataGridViewContentAlignment.TopRight:
                    strFormat.LineAlignment = StringAlignment.Near;
                    strFormat.Alignment = StringAlignment.Far;
                    break;
            }
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            string outString;
            try
            {
                FarsiCalendarComponent.FarsiDate fd = new FarsiCalendarComponent.FarsiDate();
                fd.GeoDate = (DateTime)value;
                outString = fd.FarsiDateValue;
            }
            catch
            {
                outString = "";
            }

            using (SolidBrush textbrush = new SolidBrush(textColor))
            {
                graphics.DrawString(outString, cellStyle.Font, textbrush, cellBounds, strFormat);
            }
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }
    }
}
