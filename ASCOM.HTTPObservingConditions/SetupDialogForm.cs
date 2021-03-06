using ASCOM.HTTPWeather;
using ASCOM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.HTTPWeather
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        TraceLogger tl; // Holder for a reference to the driver's trace logger

        public SetupDialogForm(TraceLogger tlDriver)
        {
            InitializeComponent();

            // Save the provided trace logger for use within the setup dialogue
            tl = tlDriver;

            // Initialise current values of user settings from the ASCOM Profile
            InitUI();
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here
            // Update the state variables with results from the dialogue
            if(comboBoxLastServer.SelectedItem != null)
            {
                ObservingConditions.LastServer = (string)comboBoxLastServer.SelectedItem;
            } else if (comboBoxLastServer.Text != "")
            {
                comboBoxLastServer.Items.Add(comboBoxLastServer.Text);
                ObservingConditions.LastServer = (string)comboBoxLastServer.Text;
            }
            tl.Enabled = chkTrace.Checked;

            tl.LogMessage("SetupDialog", $"Selected item {ObservingConditions.LastServer}");
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("https://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void InitUI()
        {
            chkTrace.Checked = tl.Enabled;
            // set the list of com ports to those that are currently available
            comboBoxLastServer.Items.Clear();
            comboBoxLastServer.Items.AddRange(ObservingConditions.favouriteServers.ToArray());
            // select the current port if possible
            if (comboBoxLastServer.Items.Contains(ObservingConditions.lastServer))
            {
                comboBoxLastServer.SelectedItem = ObservingConditions.lastServer;
            }
        }
    }
}