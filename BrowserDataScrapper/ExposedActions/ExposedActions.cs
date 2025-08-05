using BrowserDataScrapper.WebActions.Interfaces;
using BrowserDataScrapper.WebActions.Services;
using System;
using System.Runtime.InteropServices;

namespace BrowserDataScrapper.ExposedActions
{
    [ComVisible(true)]
    [Guid("22093B7B-8F9F-4F5E-9786-ECC5E771AA71")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ExposedActions : IExposedActions
    {

        private IBrowserSetActions _browserSetActions;
        private IBrowserGetActions _browserGetActions;

        public ExposedActions(IBrowserSetActions browserSetActions, IBrowserGetActions browserGetActions)
        {
            _browserGetActions = browserGetActions;
            _browserSetActions = browserSetActions;
        }

        public string GetPageSourceAsString(string url)
        {
            return _browserGetActions.GetPageSourceAsString(url);
        }
        public string GetElementValueById(string url, string id)
        {
            return _browserGetActions.GetElementValueById(url, id);
        }
        public string InvokeJavascript(string url, string command)
        {
            return _browserSetActions.InvokeJavascript(url, command);
        }
        public void SetElementById(string url, string id, string setTo)
        {
            _browserSetActions.SetElementById(url, id, setTo);
        }
        public string GetElementWithCustomQuery(string url, string query)
        {
            return _browserGetActions.GetElementWithCustomQuery(url, query);
        }


    }
}
