using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FarsiCalendarComponent
{
    class FarsiDatePickerCellControl : FarsiCalendarComponent.FarsiDatePicker, IDataGridViewEditingControl
    {
        public FarsiDatePickerCellControl()
        {
            this.CalendarControl.SelectDay += new FarsiCalendarEventHandler(CalendarControl_SelectDay);
        }

        void CalendarControl_SelectDay(object sender)
        {
            EditingControlDataGridView.EndEdit();
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }

        private DataGridView dataGridView;

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return this.dataGridView;
            }
            set
            {
                this.dataGridView = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                FarsiCalendarComponent.FarsiDate fd = new FarsiDate();
                fd.GeoDate = (DateTime)this.GeoDate;
                return fd.FarsiDateValue;
            }
            set
            {
                FarsiCalendarComponent.FarsiDate fd = new FarsiDate();
                fd.FarsiDateValue = (string)value;
                this.GeoDate = fd.GeoDate;
            }
        }

        int rowIndex;

        public int EditingControlRowIndex
        {
            get
            {
                return this.rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        private bool valueChanged = false;

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (selectAll)
                this.SelectAll();
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public override void  OnValueChangedByUser()
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChangedByUser();
        }
    }
}
