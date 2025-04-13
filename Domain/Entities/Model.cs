namespace Domain.Entities;

public class Model
{
    public Guid Id { get; set; }
    
    public Guid MakeId { get; set; }
    
    public required Make Make { get; set; }
    
    public required string Name { get; set; }
}