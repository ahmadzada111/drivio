using Drivio.Domain.Entities;
using Drivio.Domain.Enums;
using Drivio.Domain.RepositoryContracts;

namespace Drivio.Service.Abstractions.Abstractions;

public interface ISignUpStrategy<in TDto>
{
    public UserCreationResult CreateUserObject(TDto dto);

    Task AddUserDataAsync(UserCreationResult result, IUnitOfWork unitOfWork);
}

public record UserCreationResult(
    ApplicationUser IdentityUser,
    BaseUser BaseUser,
    string UserRole);