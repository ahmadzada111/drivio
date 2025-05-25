using Drivio.Domain.Enums;

namespace Drivio.Domain.Entities;

public class Seller : BaseUser
{
    public SellerType SellerType { get; set; }
    
    public string? CompanyName { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public ICollection<Announcement> Announcements { get; set; } = [];
}