using LyricsApp.WebApp.Base;
using LyricsApp.WebApp.Responses;
using LyricsApp.Genres.Commands;
using LyricsApp.Genres.DTOs;
using LyricsApp.Genres.Queries;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LyricsApp.WebApp;

public class GenresController : LyricsAppController
{
    public GenresController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ActionResult<ApiSuccess<ICollection<GenreDto>>>> GetAll()
    {
        var genres = await mediator.Send(new GenresQuery());

        return Ok(new ApiSuccess<ICollection<GenreDto>>(genres));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiSuccess<GenreDto>>> GetById(Guid id)
    {
        var genre = await mediator.Send(new GenreByIdQuery(id));

        if (genre is null)
        {
            return NotFound();
        }

        return Ok(new ApiSuccess<GenreDto>(genre));
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateGenreCommand command)
    {
        var genre = await mediator.Send(command);

        return Ok(new ApiSuccess<GenreDto>(genre));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGenreCommand command)
    {
        if (id != command.GenreId)
        {
            return BadRequest();
        }

        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteGenreCommand command)
    {
        if (id != command.GenreId)
        {
            return BadRequest();
        }

        await mediator.Send(command);

        return NoContent();
    }
}
