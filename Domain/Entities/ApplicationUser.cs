using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public Guid BaseUserId { get; set; }
    
    public BaseUser BaseUser { get; set; }
}