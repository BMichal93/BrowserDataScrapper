using BrowserDataScrapperInstaller.ControlsActions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserDataScrapperInstaller.ControlsActions.Services
{
    public class NavigatorActions : INavigatorActions
    {

        public string CancelInstallation(Form installerForm)
        {
            var result = "Installation not cancelled";
            var dialog = MessageBox.Show("Are you sure you want to cancel the installation?", "Cancel Installation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                installerForm.Close();
                result = "Installation cancelled";
            }
            return result;
        }

        public string NextStep(TabPage tabpageToOpen, TabControl tabControl)
        {
            tabControl.SelectedTab = tabpageToOpen;
            return "Next step opened";

        }
    }
}
