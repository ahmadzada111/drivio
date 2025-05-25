using Drivio.Contracts.Dto;
using Drivio.Service.Abstractions.ServiceContracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Drivio.Presentation.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    private readonly IClientService _clientService;
    private readonly IAuthService _authService;
    private readonly IJwtService _jwtService;
    private readonly IValidator<SignUpSellerDto> _signUpSellerValidator;
    private readonly IValidator<SignUpClientDto> _signUpClientValidator;
    
    public AuthController(
        IClientService clientService, 
        IAuthService authService, 
        IJwtService jwtService, 
        IValidator<SignUpSellerDto> signUpSellerValidator, 
        IValidator<SignUpClientDto> signUpClientValidator)
    {
        _clientService = clientService;
        _authService = authService;
        _jwtService = jwtService;
        _signUpSellerValidator = signUpSellerValidator;
        _signUpClientValidator = signUpClientValidator;
    }
    
    [HttpPost("signup/seller")]
    public async Task<IActionResult> SignUpSeller(SignUpSellerDto request)
    {
        var validationResult = await _signUpSellerValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
        
        var result = await _authService.SignUpUserAsync(request);
        return Ok(result);
    }
    
    [HttpPost("signup/client")]
    public async Task<IActionResult> SignUpClient(SignUpClientDto request)
    {
        var validationResult = await _signUpClientValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
        
        var result = await _authService.SignUpUserAsync(request);
        return Ok(result);
    }
}