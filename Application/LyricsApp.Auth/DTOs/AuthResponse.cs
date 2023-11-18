namespace LyricsApp.Auth.DTOs
{
    public record AuthResponse(string AccessToken, string RefreshToken, string AuthId);
}