using System;
using LyricsApp.Songs.DTOs;
using LyricsApp.Songs.Repositories;
using MediatR;

namespace LyricsApp.Songs.UseCases.Queries
{
    public class GetSongsByUserQuery : IRequest<IEnumerable<SongDto>>
    {

    }

    public class GetSongsByUserQueryHandler : IRequestHandler<GetSongsByUserQuery, IEnumerable<SongDto>>
    {
        private readonly ISongRepository songRepository;

        public GetSongsByUserQueryHandler(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }

        public async Task<IEnumerable<SongDto>> Handle(GetSongsByUserQuery request, CancellationToken cancellationToken)
        {
            var userId = Guid.NewGuid();
            var songs = await songRepository.GetSongsByUserAsync(userId);

            return songs.Select(x => new SongDto(x.Id, x.Title, x.Lyric));
        }
    }
}

