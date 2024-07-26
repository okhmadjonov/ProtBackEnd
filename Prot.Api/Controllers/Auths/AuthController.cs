using Microsoft.AspNetCore.Mvc;
using Prot.Api.FluentValidation;
using Prot.Domain.Dto.Users;
using Prot.Domain.Models.Response;
using Prot.Domain.Models.Users;
using Prot.Service.Extentions;
using Prot.Service.Interfaces.Auths;
namespace Prot.Api.Controllers.Auths;

[Route("customapi/[controller]")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    protected readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository) => _authRepository = authRepository;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var validator = new LoginDtoValidator();
        var validationResult = validator.Validate(loginDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
        }

        return ResponseHandler.ReturnIActionResponse(await _authRepository.Login(loginDto));

    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(ResponseModel<UserModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseModel<>), StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> CreateAsync(UserForCreationDto user)
    {
        var validator = new RegisterValidator();
        var validationResult = validator.Validate(user);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
        }
        return ResponseHandler.ReturnIActionResponse(await _authRepository.Registration(user));

    }
}
