using Drivio.Domain.Enums;

namespace Drivio.Domain.Entities;

public class Engine
{
    public int HorsePower { get; set; } 
        
    public EngineType EngineType { get; set; }
    
    public FuelType FuelType { get; set; }
    
    public int EngineVolumeCubicCm { get; set; }
}