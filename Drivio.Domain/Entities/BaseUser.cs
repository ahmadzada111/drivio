namespace Drivio.Domain.Entities;

public abstract class BaseUser
{
    public Guid Id { get; set; }
    
    public ApplicationUser ApplicationUser { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? RefreshToken { get; set; }
    
    public DateTimeOffset? RefreshTokenExpires { get; set; }
}