using LyricsApp.Api.Base;
using LyricsApp.Api.Responses;
using LyricsApp.Auth.Commands;
using LyricsApp.Auth.DTOs;
using LyricsApp.Users.Commands;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace LyricsApp.Api.Controllers;

public class AuthController : LyricsAppController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("LoginWithGoogle")]
    public async Task<IActionResult> LoginWithGoogle(GoogleSignInCommand command)
    {
        try
        {
            var result = await mediator.Send(command);

            if (result.AuthId != null)
            {
                await mediator.Send(new CreateUserCommand(command.Email, command.DisplayName, result.AuthId));
            }

            return Ok(new ApiSuccess<AuthResponse>(result));
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
            return Ok(new ApiSuccess<AuthResponse>(result));
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

            if (result.AuthId != null)
            {
                await mediator.Send(new CreateUserCommand(command.Email, result.AuthId, command.DisplayName));
            }
            return Ok(new ApiSuccess<AuthResponse>(result));
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ApiError(ex.Message));
        }
    }

}