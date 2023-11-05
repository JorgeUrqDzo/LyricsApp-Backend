namespace LyricsApp.Api.Responses
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
        public string Message { get; set; }
        public T Model { get; set; }
    }
}

