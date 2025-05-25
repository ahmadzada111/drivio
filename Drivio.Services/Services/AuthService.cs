using Drivio.Contracts.Dto;
using Drivio.Domain.Entities;
using Drivio.Domain.Exceptions;
using Drivio.Domain.RepositoryContracts;
using Drivio.Service.Abstractions.Abstractions;
using Drivio.Service.Abstractions.ServiceContracts;
using Microsoft.AspNetCore.Identity;

namespace Drivio.Services.Services;

internal class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IStrategyFactory _strategyFactory;
    private readonly IUnitOfWork _unitOfWork;
    
    public AuthService(
        UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager, 
        IStrategyFactory strategyFactory, 
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _strategyFactory = strategyFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserSignedUpDto> SignUpUserAsync<TDto>(TDto dto) where TDto : ISignUpRequest
    {
        var strategy = _strategyFactory.GetStrategy<ISignUpRequest>();
        var userCreationResult = strategy.CreateUserObject(dto);
        
        if (await _userManager.FindByEmailAsync(dto.Email) is not null)
        {
            throw new UserExistsException("User with this email already exists");
        }
        
        await using var transaction = await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _userManager.CreateAsync(userCreationResult.IdentityUser, dto.Password);

            var createdUser = await _userManager.FindByEmailAsync(userCreationResult.IdentityUser.Email!);
            if (createdUser is null)
            {
                throw new UserNotFound("User with this email not found");
            }
            
            await _userManager.AddToRoleAsync(createdUser, nameof(userCreationResult.UserRole));
            await strategy.AddUserDataAsync(userCreationResult, _unitOfWork);
            await _unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
        
        return new UserSignedUpDto(
            userCreationResult.IdentityUser.Id, 
            userCreationResult.IdentityUser.Email!,
            userCreationResult.IdentityUser.UserName!);
    }
}