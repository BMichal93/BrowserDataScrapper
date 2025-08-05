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


        public ExposedActions()
        {
            _browserGetActions = new BrowserGetActions();
            _browserSetActions = new BrowserSetActions();
        }

        public string GetPageSourceAsString(string url, int browserTimeout = 4000)
        {
            return _browserGetActions.GetPageSourceAsString(url, browserTimeout);
        }
        public string GetElementValueById(string url, string id, int browserTimeout = 4000)
        {
            return _browserGetActions.GetElementValueById(url, id, browserTimeout);
        }
        public string InvokeJavascript(string url, string command, int browserTimeout = 4000)
        {
            return _browserSetActions.InvokeJavascript(url, command, browserTimeout);
        }
        public void SetElementById(string url, string id, string setTo, int browserTimeout = 4000)
        {
            _browserSetActions.SetElementById(url, id, setTo, browserTimeout);
        }
        public string GetElementWithCustomQuery(string url, string query, int browserTimeout = 4000)
        {
            return _browserGetActions.GetElementWithCustomQuery(url, query, browserTimeout);
        }


    }
}
