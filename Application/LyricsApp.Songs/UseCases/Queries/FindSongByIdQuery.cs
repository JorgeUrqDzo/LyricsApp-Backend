using System;

using LyricsApp.Auth.Services;
using LyricsApp.Core.Entities.Entities;
using LyricsApp.Songs.Repositories;
using MediatR;

namespace LyricsApp.Songs.UseCases.Queries
{
    public class FindSongByIdQuery : IRequest<Song?>
    {
        public required Guid Id { get; init; }
    }

    public class FindSongByIdQueryHandler : IRequestHandler<FindSongByIdQuery, Song?>
    {
        private readonly ISongRepository songRepository;
        private readonly IAppContext _appContext;

        public FindSongByIdQueryHandler(ISongRepository songRepository, IAppContext appContext)
        {
            this.songRepository = songRepository;
            _appContext = appContext;
        }

        public async Task<Song?> Handle(FindSongByIdQuery request, CancellationToken cancellationToken)
        {
            return await songRepository.FindSongById(request.Id, _appContext.GetUserId());
        }
    }
}

