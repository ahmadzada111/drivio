using System.ComponentModel.DataAnnotations;

namespace Drivio.Domain.Entities;

public class Model
{
    public Guid Id { get; set; }
    
    public Guid MakeId { get; set; }
    
    public required Make Make { get; set; }
    
    [StringLength(20)]
    public required string Name { get; set; }
}