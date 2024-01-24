using LyricsApp.Api.Base;
using LyricsApp.Api.Responses;
using LyricsApp.Auth.Commands;
using LyricsApp.Auth.DTOs;
using LyricsApp.Users.Commands;
using LyricsApp.Users.Queries;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LyricsApp.Api.Controllers;

[AllowAnonymous]
public class AuthController : LyricsAppController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize]
    [HttpGet]
    public IActionResult IsLoggedIn()
    {
        return Ok(true);
    }

    [HttpPost("LoginWithGoogle")]
    public async Task<IActionResult> LoginWithGoogle(GoogleSignInCommand command)
    {
        try
        {
            var result = await mediator.Send(command);
            Guid userId = Guid.Empty;

            if (result.AuthId != null)
            {
                userId = await mediator.Send(new CreateUserCommand(command.Email, result.AuthId, command.DisplayName));
            }

            var response = new AuthResponseDto(result.AccessToken, result.RefreshToken, userId, command.DisplayName);
            response = await mediator.Send(new JwtTokenGeneratorCommand(response));

            return Ok(new ApiSuccess<AuthResponseDto>(response));
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ApiError(ex.Message));
        }
    }

    [HttpPost("LoginWithEmailAndPassword")]
    public async Task<IActionResult> LoginWithEmailAndPassword(EmailPasswordSignInCommand command)
    {
        try
        {
            var result = await mediator.Send(command);

            var user = await mediator.Send(new GetUserByEmailQuery(command.Email));

            if (result.AuthId is null || user is null)
            {
                return BadRequest(new ApiError("User not found"));
            }

            var response = new AuthResponseDto(result.AccessToken, result.RefreshToken, user.Id, user?.DisplayName);

            response = await mediator.Send(new JwtTokenGeneratorCommand(response));

            return Ok(new ApiSuccess<AuthResponseDto>(response));
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ApiError(ex.Message));
        }
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        try
        {
            var result = await mediator.Send(command);

            Guid userId = Guid.Empty;

            if (result.AuthId != null)
            {
                userId = await mediator.Send(new CreateUserCommand(command.Email, result.AuthId, command.DisplayName));
            }

            var response = new AuthResponseDto(result.AccessToken, result.RefreshToken, userId, command.DisplayName);
            response = await mediator.Send(new JwtTokenGeneratorCommand(response));

            return Ok(new ApiSuccess<AuthResponseDto>(response));
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ApiError(ex.Message));
        }
    }

    [Authorize]
    [HttpPost("SignOut")]
    public async Task<IActionResult> SignOutSession()
    {
        await mediator.Send(new SignOutCommand());
        return NoContent();
    }


}
