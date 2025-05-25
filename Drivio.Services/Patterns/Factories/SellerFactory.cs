using Drivio.Domain.Entities;
using Drivio.Domain.Enums;
using Drivio.Service.Abstractions.Abstractions;

namespace Drivio.Services.Patterns.Factories;

public class SellerFactory : ISellerFactory
{
    public Seller Create(
        Guid id, 
        string? firstName, 
        string? lastName,
        SellerType sellerType,
        string companyName,
        string? phoneNumber,
        ApplicationUser? applicationUser = null)
    {
        return applicationUser is null 
            ? new Seller()
            {
                Id = id, 
                FirstName = firstName, 
                LastName = lastName,
                SellerType = sellerType,
                CompanyName = companyName,
                PhoneNumber = phoneNumber,
            } 
            : new Seller()
            {
                Id = id, 
                FirstName = firstName, 
                LastName = lastName,
                SellerType = sellerType,
                CompanyName = companyName,
                PhoneNumber = phoneNumber,
                ApplicationUser = applicationUser
            };
    }
}