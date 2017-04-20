using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace ProposalReportingSystem
{
    public partial class Alert : OfficeForm
    {
        private string text = "";
        public Alert(string context, string alertColor)
        {
            text = context;
            //StyleManager.Style = eStyle.Office2016;
            InitializeComponent();
            // We can get access to desktop alert window before its displayed by handling this event
            DesktopAlert.BeforeAlertDisplayed += new EventHandler(BeforeAlertDisplayed);
            _RunningAlertId++;

            eDesktopAlertColor color;

            if (alertColor == "red")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Red);
            }
            else if (alertColor == "darkred")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.DarkRed);
            }
            else if (alertColor == "darkblue")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.DarkBlue);
            }
            else if (alertColor == "blue")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Blue);
            }
            else if (alertColor == "gray")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Gray);
            }
            else if (alertColor == "bluegray")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.BlueGray);
            }
            else if (alertColor == "green")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Green);
            }
            else if (alertColor == "black")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Black);
            }
            else if (alertColor == "orange")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Orange);
            }
            else
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Default);
            }
            eAlertPosition position = (eAlertPosition)(comboLocations.SelectedItem ?? eAlertPosition.BottomRight);
            DesktopAlert.Show(text, "\uf005", eSymbolSet.Awesome, Color.Transparent, color, position, integerInput1.Value, _RunningAlertId, AlertClicked);
        }

        public Alert(string context, string alertColor, int time)
        {
            text = context;
            //StyleManager.Style = eStyle.Office2016;
            InitializeComponent();
            // We can get access to desktop alert window before its displayed by handling this event
            DesktopAlert.BeforeAlertDisplayed += new EventHandler(BeforeAlertDisplayed);
            _RunningAlertId++;

            eDesktopAlertColor color;

            if (alertColor == "red")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Red);
            }
            else if (alertColor == "darkred")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.DarkRed);
            }
            else if (alertColor == "darkblue")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.DarkBlue);
            }
            else if (alertColor == "blue")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Blue);
            }
            else if (alertColor == "gray")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Gray);
            }
            else if (alertColor == "bluegray")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.BlueGray);
            }
            else if (alertColor == "green")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Green);
            }
            else if (alertColor == "black")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Black);
            }
            else if (alertColor == "orange")
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Orange);
            }
            else
            {
                color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Default);
            }
            eAlertPosition position = (eAlertPosition)(comboLocations.SelectedItem ?? eAlertPosition.BottomRight);
            DesktopAlert.Show(text, "\uf005", eSymbolSet.Awesome, Color.Transparent, color, position, time, _RunningAlertId, AlertClicked);
        }

        void BeforeAlertDisplayed(object sender, EventArgs e)
        {
            //DesktopAlertWindow win = (DesktopAlertWindow)sender;
            // This is how to set custom colors when needed or do anything else
            // win.BackColor=Color.Red;
            // win.ForeColor=Color.Yellow;
        }

        private void labelX2_MarkupLinkClick(object sender, MarkupLinkClickEventArgs e)
        {
            System.Diagnostics.Process.Start(e.HRef);
        }

        private long _RunningAlertId = 0;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text))
            {
                MessageBoxEx.Show("Please enter alert text...");
                return;
            }
            _RunningAlertId++;
            eDesktopAlertColor color = (eDesktopAlertColor)(comboColors.SelectedItem ?? eDesktopAlertColor.Default);
            eAlertPosition position = (eAlertPosition)(comboLocations.SelectedItem ?? eAlertPosition.BottomRight);
            DesktopAlert.Show(text, "\uf005", eSymbolSet.Awesome, Color.Empty, color, position, integerInput1.Value, _RunningAlertId, AlertClicked);
        }

        private void AlertClicked(long alertId)
        {
            listBoxAdv1.Items.Insert(0, "Alert clicked, ID: " + alertId.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (System.Object item in Enum.GetValues(typeof(eDesktopAlertColor)))
                comboColors.Items.Add(item);
            comboColors.SelectedItem = eDesktopAlertColor.Default;

            foreach (System.Object item in Enum.GetValues(typeof(eAlertPosition)))
                comboLocations.Items.Add(item);
            comboLocations.SelectedItem = eAlertPosition.BottomRight;

            integerInput1.Value = DesktopAlert.AutoCloseTimeOut;
        }
    }
}