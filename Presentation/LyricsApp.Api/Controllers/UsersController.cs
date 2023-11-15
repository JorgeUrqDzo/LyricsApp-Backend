using LyricsApp.Api.Base;
using LyricsApp.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LyricsApp.Api;

public class UsersController : LyricsAppController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }
}
