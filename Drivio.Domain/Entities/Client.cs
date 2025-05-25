namespace Drivio.Domain.Entities;

public class Client : BaseUser
{
    List<Announcement>? FavouriteAnnouncements { get; set; }
}