﻿using System;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LyricsApp.WebApp.Base
{
    [ApiController]
    [Route("Api/[controller]")]
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

