using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FarsiCalendarComponent
{
    public class DataGridViewFarsiDatePickerColumn : DataGridViewColumn
    {
        public DataGridViewFarsiDatePickerColumn(): base(new DataGridViewFarsiDatePickerCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                base.CellTemplate = value;
            }
        }
    }
}
