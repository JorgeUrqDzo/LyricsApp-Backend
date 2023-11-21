using LyricsApp.Auth.Services;
using LyricsApp.Core.Entities.Exceptions;
using LyricsApp.Genres.DTOs;
using LyricsApp.Genres.Repositories;

using MediatR;

namespace LyricsApp.Genres.Queries
{
    public class GenresQuery : IRequest<ICollection<GenreDto>>
    {

    }

    public class GenresQueryHandler : IRequestHandler<GenresQuery, ICollection<GenreDto>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAppContext _appContext;

        public GenresQueryHandler(IGenreRepository genreRepository, IAppContext appContext)
        {
            _genreRepository = genreRepository;
            _appContext = appContext;
        }
        public async Task<ICollection<GenreDto>> Handle(GenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _genreRepository.GetGenresByOwnerAsync(_appContext.GetUserId(), cancellationToken);

            return genres.Select(g => new GenreDto(g.Id, g.Name)).ToList();
        }
    }

}