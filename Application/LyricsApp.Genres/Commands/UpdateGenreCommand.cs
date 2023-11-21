using LyricsApp.Auth.Services;
using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Exceptions;
using LyricsApp.Genres.Repositories;

using MediatR;

namespace LyricsApp.Genres.Commands
{
    public class UpdateGenreCommand : IRequest<Unit>
    {
        public UpdateGenreCommand(Guid genreId, string name)
        {
            GenreId = genreId;
            Name = name;
        }


        public Guid GenreId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Unit>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAppContext _appContext;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository,
                                         IAppContext appContext,
                                         IUnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;
            _appContext = appContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateGenreCommand request,
                                       CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenresByIdAsync(_appContext.GetUserId(),
                                                                  request.GenreId,
                                                                  cancellationToken);

            if (genre is null)
            {
                throw new NotFoundException();
            }

            genre.UpdateName(request.Name);

            _genreRepository.Update(genre);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}