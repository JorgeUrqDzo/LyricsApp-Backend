using System;
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

        public GetSongByIdQueryHandler(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }

        public async Task<SongDto> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            var song = await songRepository.GetSongByIdAsync(request.Id);

            if (song == null)
            {
                throw new NotFoundException("Song not found");
            }

            return new SongDto(song.Id, song.Title, song.Lyric);
        }
    }
}

