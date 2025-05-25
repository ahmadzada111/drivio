namespace Drivio.Domain.Entities;

public class Announcement
{
    public Guid Id { get; set; }
    
    public Guid ApplicationUserId { get; set; }
    
    public required ApplicationUser ApplicationUser { get; set; }
    
    public Guid MakeId { get; set; }
    
    public Make Make { get; set; }
    
    public Guid ModelId { get; set; }
    
    public Model Model { get; set; }
    
    public required AnnouncementDetails Details { get; set; }
}