using Drivio.Contracts.Dto;
using Drivio.Domain.Entities;
using Drivio.Domain.Enums;
using Drivio.Domain.RepositoryContracts;
using Drivio.Service.Abstractions.Abstractions;

namespace Drivio.Services.Patterns.Strategies;

public class SignUpClientStrategy : ISignUpStrategy<SignUpClientDto>
{
    private readonly IClientFactory _clientFactory;
    private readonly IApplicationUserFactory _appUserFactory;
    
    public SignUpClientStrategy(
        IClientFactory clientFactory, 
        IApplicationUserFactory appUserFactory, IUnitOfWork unitOfWork)
    {
        _clientFactory = clientFactory;
        _appUserFactory = appUserFactory;
    }

    public UserCreationResult CreateUserObject(SignUpClientDto dto)
    {
        var client = _clientFactory.Create(Guid.NewGuid(), dto.FirstName, dto.LastName);
        var identityUser = _appUserFactory.Create(
            Guid.NewGuid(), 
            client, 
            dto.Email,
            dto.UserName,
            dto.PhoneNumber);

        return new UserCreationResult(identityUser, client, nameof(UserRole.Client));
    }

    public async Task AddUserDataAsync(UserCreationResult result, IUnitOfWork unitOfWork)
    {
        if (result.BaseUser is not Client client)
            throw new InvalidOperationException($"Expected {nameof(Client)} type");
        
        await unitOfWork.ClientRepository.AddAsync(client);
    }
}