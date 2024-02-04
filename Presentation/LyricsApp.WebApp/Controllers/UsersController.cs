using LyricsApp.WebApp.Base;
using LyricsApp.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LyricsApp.WebApp;

public class UsersController : LyricsAppController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    
}
