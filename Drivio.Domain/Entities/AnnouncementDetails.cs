namespace Drivio.Domain.Entities;

public class AnnouncementDetails
{
    public Guid Id { get; set; }
    
    public Guid AnnouncementId { get; set; }
    
    public required Announcement Announcement { get; set; }
    
    public Engine Engine { get; set; }
    
    public Transmission Transmission { get; set; }
    
    public int Distance { get; set; }
    
    public int Weight { get; set; }

    public IEnumerable<Image> Images { get; set; } = [];
}