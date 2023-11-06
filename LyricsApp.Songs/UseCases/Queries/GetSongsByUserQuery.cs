using System;
using LyricsApp.Core.Entities;
using LyricsApp.Songs.DTOs;
using LyricsApp.Songs.Repositories;
using MediatR;

namespace LyricsApp.Songs.UseCases.Queries
{
    public class GetSongsByUserQuery : IRequest<PagedResult<SongDto>>
    {
        public GetSongsByUserQuery(int page, string query, OrderDirectionEnum order)
        {
            Page = page;
            Query = query;
            Order = order;
        }

        public int Page { get; set; }
        public string Query { get; set; }
        public OrderDirectionEnum Order { get; set; }
    }

    public class GetSongsByUserQueryHandler : IRequestHandler<GetSongsByUserQuery, PagedResult<SongDto>>
    {
        private readonly ISongRepository songRepository;

        public GetSongsByUserQueryHandler(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }

        public Task<PagedResult<SongDto>> Handle(GetSongsByUserQuery request, CancellationToken cancellationToken)
        {
            var userId = Guid.NewGuid();
            var songsPaged = songRepository.GetSongsByUserAsync(userId, request.Query, request.Page, request.Order);
            var songsDtoPaged = new PagedResult<SongDto>(songsPaged, songsPaged.Results.Select(x => new SongDto(x.Id, x.Title, x.Lyric)).ToList());


            return Task.FromResult(songsDtoPaged);
        }
    }
}

