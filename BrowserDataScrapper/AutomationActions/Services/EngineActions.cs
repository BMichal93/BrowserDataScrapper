using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.Helpers;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

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

        public bool IsBrowserExisting(string searchedElement = "Chrome_WidgetWin_1")
        {
            bool result = false;
            AutomationElement root = AutomationElement.RootElement;
            Condition condition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window);
            AutomationElementCollection windows = root.FindAll(TreeScope.Children, condition);

            foreach (AutomationElement window in windows)
            {
                string className = window.Current.ClassName;

                if (className.Contains(searchedElement))
                {
                    Condition editCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                    AutomationElement addressBar = window.FindFirst(TreeScope.Descendants, editCondition);
                    result = true;


                    break;

                }
            }
            return result;
        }
    }
}
