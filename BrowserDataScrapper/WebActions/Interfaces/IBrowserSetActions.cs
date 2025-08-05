namespace BrowserDataScrapper.WebActions.Interfaces
{
    public interface IBrowserSetActions
    {
        string InvokeJavascript(string url, string command, int browserTimeout = 4000);
        void SetElementById(string url, string id, string setTo, int browserTimeout = 4000);
    }
}
