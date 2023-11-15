namespace LyricsApp.Core.Entities;

public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }
    public int Pages { get; set; }
    public int PageSize { get; set; }
    public int PageResults { get; set; }

    // public int FirstRowOnPage
    // {

    //     get { return (CurrentPage - 1) * PageSize + 1; }
    // }

    // public int LastRowOnPage
    // {
    //     get { return Math.Min(CurrentPage * PageSize, RowCount); }
    // }
}