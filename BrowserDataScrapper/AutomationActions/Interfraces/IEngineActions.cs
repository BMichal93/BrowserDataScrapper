namespace BrowserDataScrapper.AutomationActions.Interfraces
{
    public interface IEngineActions
    {
        string InvokeBrowser(string url, bool isDefault = true);
    }
}
