using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.WebActions.Interfaces;
using System;
using System.Windows.Forms;

namespace BrowserDataScrapper.WebActions.Services
{
    public class BrowserGetActions : IBrowserGetActions
    {
        private IUIActions _uiActions;
        private IBrowserGeneralActions _browserGeneralActions;
        private const string _getPageCommand = "javascript:(function(){setTimeout(function(){try{navigator.clipboard.writeText(document.getElementsByTagName('body')[0].innerHTML).then(()=>console.log(' Full HTML copied to clipboard!')).catch(e=>console.log('❌ Copy failed: '+e));}catch(e){console.log('❌ Error: '+e);}},300);})();";
        private const string _getElementById = "javascript:(function(){setTimeout(function(){try{navigator.clipboard.writeText(document.getElementById('{0}').value).then(()=>console.log(' Full HTML copied to clipboard!')).catch(e=>console.log('❌ Copy failed: '+e));}catch(e){console.log('❌ Error: '+e);}},300);})();";
        private const string _exceptionWhenDownloading = "Exception occured when downloading page source: ";
        private const string _getElementByCustomQuery = "javascript:(function(){setTimeout(function(){try{navigator.clipboard.writeText({0}}).then(()=>console.log(' Full HTML copied to clipboard!')).catch(e=>console.log('❌ Copy failed: '+e));}catch(e){console.log('❌ Error: '+e);}},300);})();";

        public BrowserGetActions(IUIActions uiActions, IBrowserGeneralActions browserGeneralActions)
        {
            _uiActions = uiActions;
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

        [STAThread]
        public string GetElementValueById(string url, string id)
        {
            string result = null;

            _browserGeneralActions.PrepareBrowserInstance(url);

            var pageRequestResult = _uiActions.SetBrowserBarValue(string.Format(_getElementById, id));

            if (pageRequestResult.Contains("Copy failed: "))
            {
                result = _exceptionWhenDownloading + pageRequestResult;
            }
            else
            {
                result = Clipboard.GetText();
            }

            return result;
        }

        [STAThread]
        public string GetElementWithCustomQuery(string url, string query)
        {
            string result = null;

            _browserGeneralActions.PrepareBrowserInstance(url);

            var pageRequestResult = _uiActions.SetBrowserBarValue(string.Format(_getElementByCustomQuery, query));
            if (pageRequestResult.Contains("Copy failed: "))
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
