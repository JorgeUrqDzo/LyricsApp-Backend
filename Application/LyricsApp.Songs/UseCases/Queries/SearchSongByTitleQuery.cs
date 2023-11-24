using LyricsApp.Auth.Services;
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
    private readonly IAppContext _appContext;

    public SearchSongByTitleQueryHandler(ISongRepository songRepository, IAppContext appContext)
    {
        this.songRepository = songRepository;
        _appContext = appContext;
    }

    public async Task<IEnumerable<SearchSongsDto>> Handle(SearchSongByTitleQuery request, CancellationToken cancellationToken)
    {
        var songs = await songRepository.SearchSongsByTitle(request.Title, _appContext.GetUserId());
        var songsDto = songs.Select(x => 
            new SearchSongsDto(
                x.Id, 
                x.Title, 
                x.Genre != null ? new GenreDto(x.Genre.Id, x.Genre.Name) : null
            )
        );

        return songsDto;
    }
}
