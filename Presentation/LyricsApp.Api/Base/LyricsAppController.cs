using System;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LyricsApp.Api.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize]
    public class LyricsAppController : ControllerBase
    {
        protected readonly IMediator mediator;

        public LyricsAppController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}

