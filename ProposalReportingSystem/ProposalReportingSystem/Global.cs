using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProposalReportingSystem
{
    public class Global
    {
        private String ConnectionString;
        private int systemWidth;    //related to setSize
        private int systemHeight;   //related to setSize


        public Global()
        {
            systemWidth = SystemInformation.PrimaryMonitorSize.Width;     //related to setSize
            systemHeight = SystemInformation.PrimaryMonitorSize.Height;   //related to setSize
        }


        //***//related to setSize
        public void setSize(Control controlObject, int x, int y, int w, int h)
        {
            controlObject.SetBounds(((x * systemWidth) / 1000), ((y * systemHeight) / 1000), ((w * systemWidth) / 1000), ((h * systemHeight) / 1000));
        }
        public void setDivSize(Control controlObject, int x, int y, int w, int h, int div)
        {
            controlObject.SetBounds(((x * systemWidth) / div), ((y * systemHeight) / div), ((w * systemWidth) / div), ((h * systemHeight) / div));
        }
        //***//related to setSize


        public String getConnectionString()
        {
            return ConnectionString;
        }
    }

}