namespace LyricsApp.Auth.Settings
{
    public class AuthenticationSettings
    {
        public string SupabaseUrl { get; set; } = string.Empty;
        public string SupabaseKey { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string IssuerSigningKey { get; set; } = string.Empty;
    }
}