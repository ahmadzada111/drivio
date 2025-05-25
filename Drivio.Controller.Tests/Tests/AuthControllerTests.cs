using Drivio.Contracts.Dto;
using Drivio.Domain.Enums;
using Drivio.Presentation.Controllers;
using Drivio.Service.Abstractions.ServiceContracts;
using Drivio.Services.Validators;
using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Drivio.Controller.Tests.Tests;

public class AuthControllerTests
{
    private readonly Mock<IClientService> _clientService;
    private readonly Mock<IAuthService> _authService;
    private readonly Mock<IJwtService> _jwtService;
    private readonly SignUpSellerDtoValidator _signUpSellerValidator;
    private readonly SignUpClientDtoValidator _signUpClientValidator;
    private readonly AuthController _controller;
    
    public AuthControllerTests()
    {
        _clientService = new Mock<IClientService>();
        _authService = new Mock<IAuthService>();
        _jwtService = new Mock<IJwtService>();
        _signUpSellerValidator = new SignUpSellerDtoValidator();
        _signUpClientValidator = new SignUpClientDtoValidator();
        
        //SUT
        _controller = new AuthController(
            _clientService.Object, 
            _authService.Object, 
            _jwtService.Object,
            _signUpSellerValidator,
            _signUpClientValidator);
    }
    
    [Fact]
    public async Task AuthController_SignUp_Client_Returns200()
    {
        //Arrange
        var request = new SignUpClientDto(
            "john@test.com",
            "Password1234!",
            "Password1234!",
            "John",
            "Doe",
            string.Empty,
            "john_doe1");
        var expectedResult = new UserSignedUpDto(
            Guid.NewGuid(),
            "john@test.com",
            "john_doe1");
        var validationResult = await _signUpClientValidator.TestValidateAsync(request);
        
        validationResult.ShouldNotHaveAnyValidationErrors();
        _authService
            .Setup(x => x.SignUpUserAsync(It.IsAny<ISignUpRequest>()))
            .ReturnsAsync(expectedResult);
        
        //Act
        var result = await _controller.SignUpClient(request);
        
        //Assert
        result.Should().BeOfType<OkObjectResult>();
        ((OkObjectResult)result).Value.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task AuthController_SignUp_Seller_Returns200()
    {
        //Arrange
        var request = new SignUpSellerDto(
            "johnandsons",
            string.Empty,
            "John",
            "Doe",
            SellerType.Individual,
            "John & Sons",
            "john&sons@test.com",
            "Password1234!",
            "Password1234!"
            );
        var expectedResult = new UserSignedUpDto(
            Guid.NewGuid(),
            "john&sons@test.com",
            "johnandsons");
        var validationResult = await _signUpSellerValidator.TestValidateAsync(request);
    
        validationResult.ShouldNotHaveAnyValidationErrors();
        
        _authService
            .Setup(x => x.SignUpUserAsync(It.IsAny<ISignUpRequest>()))
            .ReturnsAsync(expectedResult);
        
        //Act
        var result = await _controller.SignUpSeller(request);
        
        //Assert
        result.Should().BeOfType<OkObjectResult>();
        ((OkObjectResult)result)!.Value.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public void AuthController_SignUp_Returns400()
    {
        //Arrange
        
        //Act
        
        //Assert
    }
    
    [Fact]
    public void AuthController_SignUp_Returns401()
    {
        //Arrange
        
        //Act
        
        //Assert
    }
}