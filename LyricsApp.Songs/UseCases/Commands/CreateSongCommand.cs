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

        public CreateSongCommandHandler(ISongRepository songRepository, IUnitOfWork unitOfWork)
        {
            this.songRepository = songRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SongDto> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var newSong = new Song(Guid.NewGuid(), request.Title, request.Lyric, Guid.Empty);

            await songRepository.CreateSongAsync(newSong);

            await unitOfWork.SaveChanges();

            return new SongDto(newSong.Id, newSong.Title, newSong.Lyric);
        }
    }
}

