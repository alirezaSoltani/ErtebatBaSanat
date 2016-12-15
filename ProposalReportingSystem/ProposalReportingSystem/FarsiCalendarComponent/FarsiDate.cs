using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace FarsiCalendarComponent
{
    public class FarsiDateInvalidFormatStringException : Exception
    {
    }

    public class FarsiDateInvalidDateValueException : Exception
    {
    }

    public delegate void FarsiDateEventHandler();

    public class FarsiDate
    {
        private PersianCalendar pCalendar = new PersianCalendar();
        private DateTime geoDate;

        public event FarsiDateEventHandler DateChanged;

        public DateTime GeoDate
        {
            get
            {
                SetGeoDate();
                return geoDate;
            }
            set
            {
                geoDate = value;
                _Year = pCalendar.GetYear(geoDate);
                _Month = pCalendar.GetMonth(geoDate);
                _Day = pCalendar.GetDayOfMonth(geoDate);
                // Event
                if (DateChanged != null)
                    DateChanged();
            }
        }

        // Format YY/MM/DD
        public string FarsiDateValue
        {
            get
            {
                return TwoDigitYear.ToString("D2") + "/" +
                    Month.ToString("D2") + "/" +
                    Day.ToString("D2");
            }
            set
            {
                string txt = value;
                int i = txt.IndexOfAny(new char[] { '/', '-' });
                if (i == -1)
                    throw new FarsiDateInvalidFormatStringException();
                _Year = int.Parse(txt.Substring(0, i)) + 1300;  // Get Year 13YY/MM/DD
                txt = txt.Substring(i + 1);             // Skip YY/
                i = txt.IndexOfAny(new char[] { '/', '-' });
                if (i == -1)
                    throw new FarsiDateInvalidFormatStringException();
                _Month = int.Parse(txt.Substring(0, i)); // Get Month
                txt = txt.Substring(i + 1);             // Skip MM/
                _Day = int.Parse(txt);
            }
        }

        public FarsiDate()
        {
            // Values
            geoDate = DateTime.Now;
            _Year = pCalendar.GetYear(geoDate);
            _Month = pCalendar.GetMonth(geoDate);
            _Day = pCalendar.GetDayOfMonth(geoDate);
        }

        public FarsiDate(int year, int month, int day)
        {
            // Values
            _Year = year;
            _Month = month;
            _Day = day;
            SetGeoDate();
        }

        private int _Year;
        public int Year
        {
            get { return _Year; }
            set
            {
                _Year = value; SetGeoDate(); 
                if (DateChanged != null)
                    DateChanged();
            }
        }

        public int TwoDigitYear
        {
            get { return _Year % 100; }
        }

        private int _Month;
        public int Month
        {
            get { return _Month; }
            set 
            {
                if (value <= 0 || value > 12)
                    throw new FarsiDateInvalidDateValueException();

                _Month = value; SetGeoDate();
                if (DateChanged != null)
                    DateChanged();
            }
        }

        private int _Day;
        public int Day
        {
            get { return _Day; }
            set
            {
                if (value <= 0 || value > 31)
                    throw new FarsiDateInvalidDateValueException();
                _Day = value; SetGeoDate(); 
                if (DateChanged != null)
                    DateChanged();
            }
        }

        private void SetGeoDate()
        {
            if (_Day > DaysInMonth)
                _Day = DaysInMonth;
            geoDate = pCalendar.ToDateTime(_Year, _Month, _Day, 0, 0, 0, 0);
        }

        public int DayOfWeek
        {
            get {
                return ((int)pCalendar.GetDayOfWeek(geoDate) + 1) % 7;
            }
        }

        public int DaysInMonth
        {
            get {
                return pCalendar.GetDaysInMonth(_Year, _Month);
            }
        }

        public int DaysInPrevMonth
        {
            get {
                int m = _Month - 1;
                int y = _Year;
                if (m <= 0)
                {
                    m = 12;
                    y--;
                }
                return pCalendar.GetDaysInMonth(y, m);
            }
        }

        public int FirstDayOfMonth
        {
            get {
                FarsiDate fd = new FarsiDate(_Year, _Month, 1);
                return fd.DayOfWeek;
            }
        }
        
        public int MaxYear
        {
            get {
                return pCalendar.GetYear(pCalendar.MaxSupportedDateTime);
            }
        }

        public int MinYear
        {
            get {
                return pCalendar.GetYear(pCalendar.MinSupportedDateTime);
            }
        }

        public FarsiDate Today
        {
            get {  
                FarsiDate retFD = new FarsiDate();
                retFD.DateChanged = this.DateChanged;
                return retFD;
            }
        }

        public static bool IsToday(int year, int month, int day)
        {
            FarsiDate fd = new FarsiDate();
            if (fd.Year == year &&
                fd.Month == month &&
                fd.Day == day)
                return true;
            else
                return false;
        }

        public FarsiDate AddMonth(int month)
        {
            int m = _Month + month;
            int y = _Year + month / 12;
            if (m > 12)
            {
                m -= 12;
                y++;
            }
            if (m <= 0)
            {
                m += 12;
                y--;
            }
            int d;
            FarsiDate temp = new FarsiDate(y, m, 1);
            if (_Day > temp.DaysInMonth)
                d = temp.DaysInMonth;
            else
                d = _Day;
            // Event
            if (DateChanged != null)
                DateChanged();
            FarsiDate retFD = new FarsiDate(y, m, d);
            retFD.DateChanged = this.DateChanged;
            return retFD;
        }

        public FarsiDate AddDay(int day)
        {
            if (day > DaysInMonth || day < -DaysInPrevMonth)
                throw new ArgumentOutOfRangeException("day");
            FarsiDate fd = new FarsiDate(_Year, _Month, _Day);
            int d = fd.Day + day;
            if (d > fd.DaysInMonth)
            {
                d -= fd.DaysInMonth;
                fd = fd.AddMonth(1);
            }
            if (d <= 0)
            {
                d += DaysInPrevMonth;
                fd = fd.AddMonth(-1);
            }            
            fd.Day = d;
            // Event
            if (DateChanged != null)
                DateChanged();
            FarsiDate retFD = new FarsiDate(fd.Year, fd.Month, fd.Day);
            retFD.DateChanged = this.DateChanged;
            return retFD;
        }

        public static bool operator ==(FarsiDate fd1, FarsiDate fd2)
        {
            if (fd1.Year == fd2.Year &&
                fd1.Month == fd2.Month &&
                fd1.Day == fd2.Day)
                return true;
            else
                return false;
        }

        public static bool operator !=(FarsiDate fd1, FarsiDate fd2)
        {
            if (fd1.Year == fd2.Year &&
                fd1.Month == fd2.Month &&
                fd1.Day == fd2.Day)
                return false;
            else
                return true;
        }

        public override bool Equals(object obj)
        {
            FarsiDate fd = (FarsiDate)obj;
            if (this.Year == fd.Year &&
                this.Month == fd.Month &&
                this.Day == fd.Day)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void CopyEventHandler(FarsiDate fd)
        {
            fd.DateChanged = this.DateChanged;
        }
    }
}
