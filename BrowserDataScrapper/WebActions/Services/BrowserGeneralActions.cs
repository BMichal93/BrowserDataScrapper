using BrowserDataScrapper.AutomationActions;
using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.AutomationActions.Services;
using BrowserDataScrapper.WebActions.Interfaces;
using System;
using System.Threading;

namespace BrowserDataScrapper.WebActions.Services
{
    public class BrowserGeneralActions : IBrowserGeneralActions
    {
        private IEngineActions _engineActions;
        private IUIActions _uiActions;
        public BrowserGeneralActions() 
        {
            _uiActions = new UIActions();
            _engineActions = new EngineActions();
        }

        [STAThread]
        public void PrepareBrowserInstance(string url,int timeoutForBrowser = 4000)
        {
            if (!_engineActions.IsBrowserExisting())
            {
                _engineActions.InvokeBrowser(url);
            }
            else
            {
                _uiActions.SetBrowserBarValue(url);
                Thread.Sleep(timeoutForBrowser);
            }
        }
    }
}
