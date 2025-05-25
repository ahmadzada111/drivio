using Drivio.Domain.Entities;
using Drivio.Service.Abstractions.ServiceContracts;
using Microsoft.AspNetCore.Identity;

namespace Drivio.Services.Services;

internal class ClientService : IClientService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    
    public ClientService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
}