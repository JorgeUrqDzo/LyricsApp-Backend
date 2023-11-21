using LyricsApp.Auth.Services;
using LyricsApp.Genres.DTOs;
using LyricsApp.Genres.Repositories;

using MediatR;

namespace LyricsApp.Genres.Queries
{
    public class GenreByIdQuery : IRequest<GenreDto?>
    {
        public Guid GenreId { get; set; }

        public GenreByIdQuery(Guid genreId)
        {
            GenreId = genreId;
        }
    }

    public class GenreByIdQueryHandler : IRequestHandler<GenreByIdQuery, GenreDto?>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAppContext _appContext;

        public GenreByIdQueryHandler(IGenreRepository genreRepository, IAppContext appContext)
        {
            _genreRepository = genreRepository;
            _appContext = appContext;
        }

        public async Task<GenreDto?> Handle(GenreByIdQuery request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenresByIdAsync(_appContext.GetUserId(), request.GenreId, cancellationToken);

            return genre is null ? null : new GenreDto(genre.Id, genre.Name);
        }
    }
}