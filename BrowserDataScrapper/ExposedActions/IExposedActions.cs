using System;
using System.Runtime.InteropServices;

namespace BrowserDataScrapper.ExposedActions
{
    [ComVisible(true)]
    [Guid("C45E8B7C-9204-40C1-B2C0-3F67E40A24C0")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)] 
    public interface IExposedActions
    {
        string GetPageSourceAsString(string url, int browserTimeout = 4000);
        string GetElementValueById(string url, string id, int browserTimeout = 4000);
        string InvokeJavascript(string url, string command, int browserTimeout = 4000);
        void SetElementById(string url, string id, string setTo, int browserTimeout = 4000);
        string GetElementWithCustomQuery(string url, string query, int browserTimeout = 4000);
    }
}
