namespace ThreatMap.Infrastructure.Identity.Configuration;
//Identity Copy
public class AuthConfig
{
    public string JwtKey { get; set; }
    public string JwtIssuer { get; set; }
    public TimeSpan Expires { get; set; } 
    public uint RefreshTokenTTL { get; set; }
}