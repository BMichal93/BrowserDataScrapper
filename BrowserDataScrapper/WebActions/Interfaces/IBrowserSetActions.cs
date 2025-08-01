namespace BrowserDataScrapper.WebActions.Interfaces
{
    public interface IBrowserSetActions
    {
        string InvokeJavascript(string url, string command);
        void SetElementById(string url, string id, string setTo);
    }
}
