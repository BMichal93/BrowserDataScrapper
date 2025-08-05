namespace BrowserDataScrapper.WebActions.Interfaces
{
    public interface IBrowserGeneralActions
    {
        void PrepareBrowserInstance(string url, int timeoutForBrowser = 4000);
    }
}
