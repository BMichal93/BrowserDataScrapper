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
        private string _clickOnELement = "javascript:(function(){{document.getElementById('{0}').click();}})();";

        public BrowserSetActions()
        {
            _uiActions = new UIActions();
            _browserGeneralActions = new BrowserGeneralActions();
        }

        [STAThread]
        public string InvokeJavascript(string url, string command, int browserTimeout = 4000)
        {
            string result = null;

            _browserGeneralActions.PrepareBrowserInstance(url, browserTimeout);

            if (!IsCorrectJSFormat("javascript:" + command))
            {
                result = _incorrectJS;
            }
            else
            {
                var pageRequestResult = _uiActions.SetBrowserBarValue("javascript:" + command);
                result = _actionSucceeded;
            }

            return result;
        }

        [STAThread]
        public void SetElementById(string url, string id, string setTo, int browserTimeout = 4000)
        {
            _browserGeneralActions.PrepareBrowserInstance(url, browserTimeout);

            var pageRequestResult = _uiActions.SetBrowserBarValue(string.Format(_setFieldByIdCommand, id, setTo));
        }

        [STAThread]
        public void ClickOnElementById(string url, string id, int browserTimeout = 4000)
        {
            _browserGeneralActions.PrepareBrowserInstance(url, browserTimeout);
            var pageRequestResult = _uiActions.SetBrowserBarValue(string.Format(_clickOnELement,id));
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
