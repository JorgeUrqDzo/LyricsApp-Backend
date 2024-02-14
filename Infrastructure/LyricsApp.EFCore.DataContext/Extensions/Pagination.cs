using LyricsApp.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Extensions
{
    public static class Pagination
    {
        public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query,
                                                 int page,
                                                 int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalRecords = await query.CountAsync()
            };


            var pageCount = (double)result.TotalRecords / pageSize;
            result.Pages = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }
    }
}