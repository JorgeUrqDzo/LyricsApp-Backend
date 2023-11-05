using LyricsApp.Api.Base;
using LyricsApp.Api.Responses;
using LyricsApp.Songs.DTOs;
using LyricsApp.Songs.UseCases.Commands;
using LyricsApp.Songs.UseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LyricsApp.Api.Controllers
{
    public class SongsController : LyricsAppController
    {
        public SongsController(IMediator mediator) : base(mediator)
        {
        }

        // GET: api/Songs
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccess<IEnumerable<SongDto>>))]
        public async Task<IActionResult> Get()
        {
            var songs = await mediator.Send(new GetSongsByUserQuery());
            return Ok(new ApiSuccess<IEnumerable<SongDto>>(songs));
        }

        // GET: api/Songs/5
        [HttpGet("{Id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccess<SongDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiError))]
        public async Task<ActionResult<ApiSuccess<SongDto>>> Get([FromRoute] GetSongByIdQuery request)
        {
            try
            {
                var song = await mediator.Send(request);

                return Ok(new ApiSuccess<SongDto>(song));
            }
            catch (Exception ex)
            {
                return NotFound(new ApiError(ex.Message));
            }

        }

        // POST: api/Songs
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccess<SongDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        public async Task<IActionResult> Post([FromBody] CreateSongCommand command)
        {
            var createdSong = await mediator.Send(command);

            return Ok(new ApiSuccess<SongDto>(createdSong));
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccess<SongDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiError))]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSongCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest(new ApiError("The ids does not match"));
            }

            var song = await mediator.Send(new FindSongByIdQuery() { Id = id });

            if (song is null)
            {
                return NotFound(new ApiError(""));
            }

            try
            {
                await mediator.Send(request);
            }
            catch (Exception ex)
            {
                return NotFound(new ApiError(ex.Message));
            }

            return Ok(new ApiSuccess<SongDto>(new SongDto(request.Id, request.Title, request.Lyric)));
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccess<SongDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiError))]
        public async Task<IActionResult> Delete([FromRoute] FindSongByIdQuery request)
        {
            var song = await mediator.Send(request);

            if (song is null)
            {
                return NotFound(new ApiError(""));
            }

            await mediator.Send(new DeleteSongCommand() { Song = song });

            return Ok(new ApiSuccess<SongDto?>(null, "Song deleted"));
        }
    }
}
