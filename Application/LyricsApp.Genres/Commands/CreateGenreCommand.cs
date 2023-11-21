using LyricsApp.Auth.Services;
using LyricsApp.Core.Entities;
using LyricsApp.Core.Entities.Data;
using LyricsApp.Genres.DTOs;
using LyricsApp.Genres.Repositories;

using MediatR;

namespace LyricsApp.Genres.Commands
{
    public class CreateGenreCommand : IRequest<GenreDto>
    {
        public CreateGenreCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppContext _appContext;

        public CreateGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork, IAppContext appContext)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
            _appContext = appContext;
        }

        public async Task<GenreDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre(Guid.NewGuid(), request.Name, _appContext.GetUserId());

            await _genreRepository.CreateAsync(genre, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new GenreDto(genre.Id, genre.Name);
        }
    }
}