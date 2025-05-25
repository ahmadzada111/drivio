using Drivio.Contracts.Dto;
using Drivio.Domain.Entities;
using Drivio.Domain.Enums;
using Drivio.Domain.RepositoryContracts;
using Drivio.Service.Abstractions.Abstractions;

namespace Drivio.Services.Patterns.Strategies;

public class SignUpSellerStrategy : ISignUpStrategy<SignUpSellerDto>
{
    private readonly ISellerFactory _sellerFactory;
    private readonly IApplicationUserFactory _appUserFactory;
    
    public SignUpSellerStrategy(
        ISellerFactory sellerFactory, 
        IApplicationUserFactory appUserFactory, 
        IUnitOfWork unitOfWork)
    {
        _sellerFactory = sellerFactory;
        _appUserFactory = appUserFactory;
    }
    
    public UserCreationResult CreateUserObject(SignUpSellerDto dto)
    {
        var seller = _sellerFactory.Create(
            Guid.NewGuid(), 
            dto.FirstName, 
            dto.LastName,
            dto.SellerType,
            dto.CompanyName,
            dto.PhoneNumber);
        var identityUser = _appUserFactory.Create(
            Guid.NewGuid(), 
            seller, 
            dto.Email, 
            dto.UserName, 
            dto.PhoneNumber);

        return new UserCreationResult(identityUser, seller, nameof(UserRole.Seller));
    }
    
    public async Task AddUserDataAsync(UserCreationResult result, IUnitOfWork unitOfWork)
    {
        if (result.BaseUser is not Seller seller)
            throw new InvalidOperationException($"Expected {nameof(Seller)} type");
        
        await unitOfWork.SellerRepository.AddAsync(seller);
    } 
}