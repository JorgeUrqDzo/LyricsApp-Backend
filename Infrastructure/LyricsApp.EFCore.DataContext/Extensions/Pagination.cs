using LyricsApp.Core.Entities;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Extensions
{
    public static class Pagination
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                                 int page,
                                                 int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                PageResults = query.Count()
            };


            var pageCount = (double)result.PageResults / pageSize;
            result.Pages = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}