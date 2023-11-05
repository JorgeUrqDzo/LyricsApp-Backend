using System;
namespace LyricsApp.Api.Responses
{
    public class ApiError
    {
        public ApiError(string message)
        {
            Message = message;
        }

        public bool Success { get; private set; } = false;
        public string Message { get; set; }
    }
}

