namespace Domain.Entities;

public class PlatformUser : BaseUser
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }

}