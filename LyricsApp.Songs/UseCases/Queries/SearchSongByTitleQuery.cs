using LyricsApp.Songs.DTOs;
using LyricsApp.Songs.Repositories;
using MediatR;

namespace LyricsApp.Songs;

public class SearchSongByTitleQuery : IRequest<IEnumerable<SearchSongsDto>>
{
    public required string Title { get; init; }
}

public class SearchSongByTitleQueryHandler : IRequestHandler<SearchSongByTitleQuery, IEnumerable<SearchSongsDto>>
{
    private readonly ISongRepository songRepository;

    public SearchSongByTitleQueryHandler(ISongRepository songRepository)
    {
        this.songRepository = songRepository;
    }

    public async Task<IEnumerable<SearchSongsDto>> Handle(SearchSongByTitleQuery request, CancellationToken cancellationToken)
    {
        var songs = await songRepository.SearchSongsByTitle(request.Title);
        var songsDto = songs.Select(x => new SearchSongsDto(x.Id, x.Title));

        return songsDto;
    }
}
