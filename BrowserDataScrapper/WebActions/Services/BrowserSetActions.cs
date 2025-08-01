using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.WebActions.Interfaces;
using System;

namespace BrowserDataScrapper.WebActions.Services
{
    public class BrowserSetActions : IBrowserSetActions
    {
        private IUIActions _uiActions;
        private IEngineActions _engineActions;
        private const string _actionSucceeded = "Action has been successfully performed on the website.";
        private const string _incorrectJS = "Javascript is incorrect";

        public BrowserSetActions(IUIActions uiActions, IEngineActions engineActions)
        {
            _uiActions = uiActions;
            _engineActions = engineActions;
        }

        [STAThread]
        public string InvokeJavascript(string url, string command)
        {
            string result = null;
            _engineActions.InvokeBrowser(url);
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
