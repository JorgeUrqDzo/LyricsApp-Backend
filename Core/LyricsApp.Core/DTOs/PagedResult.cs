namespace LyricsApp.Core.Entities;
public class PagedResult<T> : PagedResultBase where T : class
{
    public ICollection<T> Results { get; set; }

    public PagedResult()
    {
        Results = new List<T>();
    }

    public PagedResult(PagedResultBase baseValues, ICollection<T> values)
    {
        CurrentPage = baseValues.CurrentPage;
        Pages = baseValues.Pages;
        PageSize = baseValues.PageSize;
        PageResults = baseValues.PageResults;
        Results = values;
    }
}