namespace Domain.Entities;

public class Announcement
{
    public Guid Id { get; set; }
    
    public Guid ApplicationUserId { get; set; }
    
    public required ApplicationUser ApplicationUser { get; set; }
}