using LyricsApp.Auth.Services;
using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Entities;
using LyricsApp.Core.Entities.Exceptions;
using LyricsApp.Songs.DTOs;
using LyricsApp.Songs.Repositories;

using MediatR;

namespace LyricsApp.Songs.UseCases.Commands
{
    public class FavoriteSongCommand : IRequest<SongDto>
    {
        public required Guid Id { get; init; }
        public required bool IsFavorite { get; init; }
    }

    public class FavoriteSongCommandHandler : IRequestHandler<FavoriteSongCommand, SongDto>
    {
        private readonly ISongRepository songRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAppContext _appContext;

        public FavoriteSongCommandHandler(ISongRepository songRepository, IUnitOfWork unitOfWork, IAppContext appContext)
        {
            this.songRepository = songRepository;
            this.unitOfWork = unitOfWork;
            _appContext = appContext;
        }

        public async Task<SongDto> Handle(FavoriteSongCommand request, CancellationToken cancellationToken)
        {
            var currentSong = await songRepository.GetSongByIdAsync(request.Id, _appContext.GetUserId());

            if (currentSong == null)
            {
                throw new NotFoundException($"Not found resource: {request.Id}");
            }

            currentSong.SetAsFavorite(request.IsFavorite);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new SongDto(
                currentSong.Id,
                currentSong.Title,
                currentSong.Lyric,
                new GenreDto(currentSong.GenreId ?? Guid.Empty, string.Empty),
                currentSong.IsFavorite
            );
        }
    }
}

