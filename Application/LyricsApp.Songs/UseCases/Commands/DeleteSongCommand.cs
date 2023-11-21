using System;

using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Entities;
using LyricsApp.Songs.Repositories;

using MediatR;

namespace LyricsApp.Songs.UseCases.Commands
{
    public class DeleteSongCommand : IRequest<Unit>
    {
        public required Song Song { get; init; }
    }

    public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand, Unit>
    {
        private readonly ISongRepository songRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteSongCommandHandler(ISongRepository songRepository, IUnitOfWork unitOfWork)
        {
            this.songRepository = songRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
        {
            songRepository.Delete(request.Song);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

