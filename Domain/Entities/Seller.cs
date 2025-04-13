namespace Domain.Entities;

public class Seller : BaseUser
{
    public ICollection<Announcement> Announcements { get; set; } = [];

}