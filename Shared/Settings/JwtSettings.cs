namespace Shared.Settings;

public record JwtSettings
{
    public string Secret { get; set; }
    
    public string Issuer { get; set; }
    
    public string Audience { get; set; }
    
    public int AccessTokenLifetime { get; set; }
}