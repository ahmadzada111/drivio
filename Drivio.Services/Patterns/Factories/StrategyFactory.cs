using Drivio.Contracts.Dto;
using Drivio.Service.Abstractions.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Drivio.Services.Patterns.Factories;

public class StrategyFactory : IStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;

    public StrategyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ISignUpStrategy<TDto> GetStrategy<TDto>() where TDto : ISignUpRequest
    {
        return _serviceProvider.GetRequiredService<ISignUpStrategy<TDto>>();
    }
}