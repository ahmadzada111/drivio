using Microsoft.AspNetCore.Identity;

namespace Drivio.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public Guid BaseUserId { get; set; }
    
    public BaseUser BaseUser { get; set; }
}