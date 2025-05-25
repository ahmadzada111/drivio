using Drivio.Contracts.Dto;

namespace Drivio.Service.Abstractions.ServiceContracts;

public interface IAuthService
{
    Task<UserSignedUpDto> SignUpUserAsync<TDto>(TDto dto) where TDto : ISignUpRequest;
}