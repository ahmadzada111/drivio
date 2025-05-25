using Drivio.Contracts.Dto;

namespace Drivio.Service.Abstractions.Abstractions;

public interface IStrategyFactory
{
    ISignUpStrategy<TDto> GetStrategy<TDto>() where TDto : ISignUpRequest;
}