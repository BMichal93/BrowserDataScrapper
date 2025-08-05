using System.Windows.Forms;

namespace BrowserDataScrapperInstaller.ControlsActions.Interfaces
{
    public interface INavigatorActions
    {
        string CancelInstallation(Form installerForm);
        string NextStep(TabPage tabpageToOpen, TabControl tabControl);
    }
}
