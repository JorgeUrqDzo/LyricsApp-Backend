using LyricsApp.Auth.Services;
using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Entities;
using LyricsApp.Songs.DTOs;
using LyricsApp.Songs.Repositories;
using MediatR;

namespace LyricsApp.Songs.UseCases.Commands
{
    public class CreateSongCommand : IRequest<SongDto>
    {
        public required string Title { get; init; }
        public required string Lyric { get; init; }
    }

    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, SongDto>
    {
        private readonly ISongRepository songRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAppContext _appContext;

        public CreateSongCommandHandler(ISongRepository songRepository, IUnitOfWork unitOfWork, IAppContext appContext)
        {
            this.songRepository = songRepository;
            this.unitOfWork = unitOfWork;
            _appContext = appContext;
        }

        public async Task<SongDto> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var newSong = new Song(Guid.NewGuid(), request.Title, request.Lyric, _appContext.GetUserId());

            await songRepository.CreateSongAsync(newSong);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new SongDto(newSong.Id, newSong.Title, newSong.Lyric);
        }
    }
}

