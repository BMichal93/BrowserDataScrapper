using System;
using System.Runtime.InteropServices;

namespace BrowserDataScrapper.ExposedActions
{
    [ComVisible(true)]
    [Guid("C45E8B7C-9204-40C1-B2C0-3F67E40A24C0")]
    public interface IExposedActions
    {
        string GetPageSourceAsString(string url);
        string GetElementValueById(string url, string id);
        string InvokeJavascript(string url, string command);
        void SetElementById(string url, string id, string setTo);
        string GetElementWithCustomQuery(string url, string query);
    }
}
