using BrowserDataScrapper.AutomationActions.Interfraces;
using System;
using System.Diagnostics;
using System.Threading;

namespace BrowserDataScrapper.AutomationActions
{
    public class EngineActions : IEngineActions
    {
        private const string _browserFailed = "Action failed - browser was not invoked";
        private const string _exceptionInBrowser = "Exception occured when invoking browser: ";
        private const string _browserSuccess = "Browser has been invoked successfully";
        public string InvokeBrowser(string url, bool isDefault = true)
        {
            var result = _browserFailed;
            string arguments = "--new-window " + url;
            try
            {
                if (isDefault)
                {
                    Process.Start("msedge", arguments);
                    result = _browserSuccess;
                }
                else
                {
                    Process.Start("chrome", arguments);
                    result = _browserSuccess;
                }
            }
            catch (Exception ex)
            {
                result = _exceptionInBrowser + ex.Message;

            }
            Thread.Sleep(2000); 
            return result;
        }
    }
}
