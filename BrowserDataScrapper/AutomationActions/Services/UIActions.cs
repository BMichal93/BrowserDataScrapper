using BrowserDataScrapper.AutomationActions.Interfraces;
using System.Windows.Automation;

namespace BrowserDataScrapper.AutomationActions.Services
{
    public class UIActions : IUIActions
    {
        private const string _browserFound = "Browser found successfully";
        private const string _browserDataSet = "Browser has been found and data is set successfully to: ";
        private const string _browserFailed = "Browser not found or data could not be set";

        internal string SetBrowserBarValue(string inputToBrowser, string searchedElement = "Chrome_WidgetWin_1") //This method is used to find browser bar and set its value to variable.
        {
            var result = _browserFailed;
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
                    result = _browserFound;

                    if (addressBar.TryGetCurrentPattern(ValuePattern.Pattern, out object patternObj))
                    {
                        ValuePattern valuePattern = (ValuePattern)patternObj;
                        valuePattern.SetValue(inputToBrowser);
                        result = _browserDataSet + inputToBrowser;
                    }

                    break;

                }
            }
            return result;
        }
    }
}
