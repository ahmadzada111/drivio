namespace Drivio.Domain.Entities;

public class Image
{
    public Guid Id { get; set; }
    
    public required string Url { get; set; }
}