namespace BrowserDataScrapper.WebActions.Interfaces
{
    public interface IBrowserGetActions
    {
        string GetPageSourceAsString(string url);
        string GetElementValueById(string url, string id);
        string GetElementWithCustomQuery(string url, string query);

    }
}
