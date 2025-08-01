using BrowserDataScrapper.AutomationActions.Interfraces;
using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace BrowserDataScrapper.AutomationActions.Services
{
    public class UIActions : IUIActions
    {

        public List<object> GetBrowserUI()
        {
            List<object> result = new List<object>();
            AutomationElement root = AutomationElement.RootElement;
            Condition condition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window);
            AutomationElementCollection windows = root.FindAll(TreeScope.Children, condition);

            foreach (AutomationElement window in windows)
            {
                string name = window.Current.Name;
                string className = window.Current.ClassName;

                if (name.Contains("Google Chrome") || name.Contains("Microsoft Edge"))
                {
                    Console.WriteLine($"Found browser window: {name} ({className})");
                    result.Add(new { Name = name, ClassName = className, AutomationElement = window });

                }
            }
            return result;

        }
    }
}
