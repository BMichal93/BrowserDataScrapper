using BrowserDataScrapperInstaller.ControlsActions.Interfaces;
using BrowserDataScrapperInstaller.ControlsActions.Services;
using System;
using System.Windows.Forms;

namespace BrowserDataScrapperInstaller
{
    public partial class frm_Installer : Form
    {
        private INavigatorActions _navigatorActions;
        public frm_Installer()
        {
            InitializeComponent();
            _navigatorActions = new NavigatorActions();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            _navigatorActions.CancelInstallation(this);
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            _navigatorActions.NextStep(tbp_InstallPage, tc_MainTabs);
        }
    }
}
