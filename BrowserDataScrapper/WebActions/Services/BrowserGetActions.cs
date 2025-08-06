using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.AutomationActions.Services;
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

        public BrowserGetActions()
        {
            _uiActions = new UIActions();
            _browserGeneralActions = new BrowserGeneralActions();

        }

        [STAThread]
        public string GetPageSourceAsString(string url,int browserTimeout = 4000)
        {

            return GetQuery(url, _getPageCommand, browserTimeout);

        }

        [STAThread]
        public string GetElementValueById(string url, string id, int browserTimeout = 4000)
        {

            return GetQuery(url, string.Format(_getElementById, id), browserTimeout);
        }

        [STAThread]
        public string GetElementWithCustomQuery(string url, string query, int browserTimeout = 4000)
        {
            return GetQuery(url, string.Format(_getElementByCustomQuery, query), browserTimeout);
        }

        [STAThread]
        private string GetQuery(string url, string query, int browserTimeout = 4000)
        {
            try
            {
                _browserGeneralActions.PrepareBrowserInstance(url, browserTimeout);
                var pageRequestResult = _uiActions.SetBrowserBarValue(query);
                return Clipboard.GetText();
            }
            catch (Exception ex)
            {
                return _exceptionWhenDownloading + ex.Message;
            }
        }

    }
}
