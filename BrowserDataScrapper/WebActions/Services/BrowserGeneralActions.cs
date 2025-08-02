using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.WebActions.Interfaces;
using System;
using System.Threading;

namespace BrowserDataScrapper.WebActions.Services
{
    public class BrowserGeneralActions : IBrowserGeneralActions
    {
        private IEngineActions _engineActions;
        private IUIActions _uiActions;
        public BrowserGeneralActions(IUIActions uiactions, IEngineActions engineactions) 
        {
            _uiActions = uiactions;
            _engineActions = engineactions;
        }

        [STAThread]
        public void PrepareBrowserInstance(string url)
        {
            if (!_engineActions.IsBrowserExisting())
            {
                _engineActions.InvokeBrowser(url);
            }
            else
            {
                _uiActions.SetBrowserBarValue(url);
                Thread.Sleep(3500);
            }
        }
    }
}
