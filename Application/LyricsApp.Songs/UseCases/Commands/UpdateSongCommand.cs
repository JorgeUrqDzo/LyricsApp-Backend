using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Exceptions;
using LyricsApp.Songs.DTOs;
using LyricsApp.Songs.Repositories;
using MediatR;

namespace LyricsApp.Songs.UseCases.Commands
{
    public class UpdateSongCommand : IRequest<SongDto>
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Lyric { get; init; }
    }

    public class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand, SongDto>
    {
        private readonly ISongRepository songRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateSongCommandHandler(ISongRepository songRepository, IUnitOfWork unitOfWork)
        {
            this.songRepository = songRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SongDto> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
        {
            var currentSong = await songRepository.GetSongByIdAsync(request.Id);

            if (currentSong == null)
            {
                throw new NotFoundException($"Not found resource: {request.Id}");
            }

            currentSong.Update(request.Title, request.Lyric);

            songRepository.Update(currentSong);

            await unitOfWork.SaveChanges();

            return new SongDto(currentSong.Id, currentSong.Title, currentSong.Lyric);
        }
    }
}

