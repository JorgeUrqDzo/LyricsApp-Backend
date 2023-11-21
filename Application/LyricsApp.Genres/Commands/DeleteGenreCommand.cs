using LyricsApp.Auth.Services;
using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Exceptions;
using LyricsApp.Genres.Repositories;

using MediatR;

namespace LyricsApp.Genres.Commands
{
    public class DeleteGenreCommand : IRequest<Unit>
    {
        public DeleteGenreCommand(Guid genreId)
        {
            GenreId = genreId;
        }


        public Guid GenreId { get; set; }
    }

    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Unit>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAppContext _appContext;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteGenreCommandHandler(IGenreRepository genreRepository,
                                         IAppContext appContext,
                                         IUnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;
            _appContext = appContext;
            _unitOfWork = unitOfWork;

        }
        public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenresByIdAsync(_appContext.GetUserId(),
                                                                  request.GenreId,
                                                                  cancellationToken);
            if (genre is null)
            {
                throw new NotFoundException();
            }

            _genreRepository.Remove(genre);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}