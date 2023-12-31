﻿using LyricsApp.Auth;
using LyricsApp.Genres;
using LyricsApp.Songs;
using LyricsApp.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LyricsApp.Application.IoC;

public static class DependencyContainer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddLyricsUsers();
        services.AddSongs();
        services.AddAuth();
        services.AddGenres();
        
        return services;
    }
}
