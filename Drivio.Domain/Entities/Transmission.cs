using Drivio.Domain.Enums;
using DriveType = Drivio.Domain.Enums.DriveType;

namespace Drivio.Domain.Entities;

public class Transmission
{
    public TransmissionType Type { get; set; }
    
    public DriveType Drive { get; set; }
}