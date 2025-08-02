using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.WebActions.Interfaces;
using System;
using System.Windows.Forms;

namespace BrowserDataScrapper.WebActions.Services
{
    public class BrowserGetActions : IBrowserGetActions
    {
        private IUIActions _uiActions;
        private IEngineActions _engineActions;
        private IBrowserGeneralActions _browserGeneralActions;
        private const string _getPageCommand = "javascript:(function(){setTimeout(function(){try{navigator.clipboard.writeText(document.getElementsByTagName('body')[0].innerHTML).then(()=>console.log(' Full HTML copied to clipboard!')).catch(e=>console.log('❌ Copy failed: '+e));}catch(e){console.log('❌ Error: '+e);}},300);})();";
        private const string _exceptionWhenDownloading = "Exception occured when downloading page source: ";
        

        public BrowserGetActions(IUIActions uiActions, IEngineActions engineActions, IBrowserGeneralActions browserGeneralActions)
        {
            _uiActions = uiActions;
            _engineActions = engineActions;
            _browserGeneralActions = browserGeneralActions;

        }

        [STAThread]
        public string GetPageSourceAsString(string url)
        {
            string result = null;

            _browserGeneralActions.PrepareBrowserInstance(url);

            var pageRequestResult = _uiActions.SetBrowserBarValue(_getPageCommand);

            if(pageRequestResult.Contains("Copy failed: "))
            {
                result = _exceptionWhenDownloading + pageRequestResult;
            }
            else
            {
                result = Clipboard.GetText();
            }

            return result;

        }

    }
}
