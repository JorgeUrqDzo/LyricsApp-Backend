using System;

using LyricsApp.Auth.Services;
using LyricsApp.Core.Entities.Exceptions;
using LyricsApp.Songs.DTOs;
using LyricsApp.Songs.Repositories;
using MediatR;

namespace LyricsApp.Songs.UseCases.Queries
{
    public class GetSongByIdQuery : IRequest<SongDto>
    {
        public required Guid Id { get; init; }
    }

    public class GetSongByIdQueryHandler : IRequestHandler<GetSongByIdQuery, SongDto>
    {
        private readonly ISongRepository songRepository;
        private readonly IAppContext _appContext;


        public GetSongByIdQueryHandler(ISongRepository songRepository, IAppContext appContext)
        {
            this.songRepository = songRepository;
            _appContext = appContext;

        }

        public async Task<SongDto> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            var song = await songRepository.GetSongByIdAsync(request.Id, _appContext.GetUserId());

            if (song == null)
            {
                throw new NotFoundException("Song not found");
            }

            return new SongDto(song.Id, song.Title, song.Lyric);
        }
    }
}

