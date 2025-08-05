namespace BrowserDataScrapper.WebActions.Interfaces
{
    public interface IBrowserGetActions
    {
        string GetPageSourceAsString(string url, int browserTimeout=4000);
        string GetElementValueById(string url, string id, int browserTimeout = 4000);
        string GetElementWithCustomQuery(string url, string query, int browserTimeout = 4000);

    }
}
