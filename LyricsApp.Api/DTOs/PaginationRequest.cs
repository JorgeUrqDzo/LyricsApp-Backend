using System.ComponentModel;
using LyricsApp.Core.Entities;

namespace LyricsApp.Api;

public class PaginationRequest
{
    public PaginationRequest()
    {

    }

    public PaginationRequest(int page = 1, string query = "", OrderDirectionEnum order = 0)
    {
        if (!Enum.IsDefined(typeof(OrderDirectionEnum), order))
        {
            throw new ArgumentOutOfRangeException(nameof(order));
        }

        Page = page < 1 ? 1 : page; ;
        Query = string.IsNullOrWhiteSpace(query) ? string.Empty : query;
        Order = order;
    }

    public string Query { get; set; } = string.Empty;

    private int _page = 1;

    [DefaultValue(1)]
    public int Page
    {
        get { return _page; }
        set
        {
            _page = value < 1 ? 1 : value;
        }
    }

    [DefaultValue("0")]
    public OrderDirectionEnum Order { get; set; } = OrderDirectionEnum.ASC;
}
