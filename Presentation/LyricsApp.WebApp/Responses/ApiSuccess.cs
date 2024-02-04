namespace LyricsApp.WebApp.Responses
{
    public class ApiSuccess<T>
    {
        public ApiSuccess(T model)
        {
            Model = model;
        }

        public ApiSuccess(T model, string message)
        {
            Model = model;
            Message = message;
        }

        public bool Success { get; private set; } = true;
        public string Message { get; set; } = string.Empty;
        public T Model { get; set; }
    }


    public class ApiSuccessPaged<T> : ApiSuccess<T>
    {
        public ApiSuccessPaged(T model) : base(model)
        {
        }

        public ApiSuccessPaged(T model, int page, bool next, bool prev, int totalItems, int pageItems) : base(model)
        {
            Page = page;
            Next = next;
            Prev = prev;
            TotalItems = totalItems;
            PageItems = pageItems;
        }

        public int Page { get; init; }
        public bool Next { get; init; }
        public bool Prev { get; init; }
        public int TotalItems { get; init; }
        public int PageItems { get; init; }
    }
}

