using System.ComponentModel.DataAnnotations;

namespace Drivio.Domain.Entities;

public class Make
{
    public Guid Id { get; set; }
    
    [StringLength(20)]
    public required string Name { get; set; }

    public ICollection<Model> Models { get; set; } = [];
}