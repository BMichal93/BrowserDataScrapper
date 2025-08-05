using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.AutomationActions.Services;
using BrowserDataScrapper.WebActions.Interfaces;
using System;

namespace BrowserDataScrapper.WebActions.Services
{
    public class BrowserSetActions : IBrowserSetActions
    {
        private IUIActions _uiActions;
        private IBrowserGeneralActions _browserGeneralActions;
        private const string _actionSucceeded = "Action has been successfully performed on the website.";
        private const string _incorrectJS = "Javascript is incorrect";
        private string _setFieldByIdCommand = "javascript:(function(){{document.getElementById('{0}').value = '{1}';}})();";

        public BrowserSetActions()
        {
            _uiActions = new UIActions();
            _browserGeneralActions = new BrowserGeneralActions();
        }

        [STAThread]
        public string InvokeJavascript(string url, string command)
        {
            string result = null;

            _browserGeneralActions.PrepareBrowserInstance(url);

            if (!IsCorrectJSFormat(command))
            {
                result = _incorrectJS;
            }
            else
            {
                var pageRequestResult = _uiActions.SetBrowserBarValue(command);
                result = _actionSucceeded;
            }

            return result;
        }

        [STAThread]
        public void SetElementById(string url, string id, string setTo)
        {
            _browserGeneralActions.PrepareBrowserInstance(url);

            var pageRequestResult = _uiActions.SetBrowserBarValue(string.Format(_setFieldByIdCommand, id, setTo));
        }

        private bool IsCorrectJSFormat(string command)
        {
            if (command.StartsWith("javascript:") && command.EndsWith(";"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
