using Drivio.Domain.Entities;
using Drivio.Domain.Enums;

namespace Drivio.Service.Abstractions.Abstractions;

public interface ISellerFactory
{
    Seller Create(
        Guid id,
        string? firstName,
        string? lastName,
        SellerType sellerType,
        string companyName,
        string? phoneNumber,
        ApplicationUser? applicationUser = null);
}