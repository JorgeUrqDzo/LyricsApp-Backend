namespace LyricsApp.Auth.DTOs
{
    public record AuthResponse(string AccessToken, string RefreshToken, string AuthId);
    public record AuthResponseDto(string AccessToken, string RefreshToken, Guid UserId, string? DisplayName);
}