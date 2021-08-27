using System;
using System.Linq;

namespace ClienteDemo.Core.Helpers
{
    public static class PagingExtension
    {
        public static DataCollection<T> Paging<T>(this IQueryable<T> query, int page, int take)
        {
            int originalPages = page;

            if (page > 0)
            {
                page = page * take;
            }

            var result = new DataCollection<T>
            {
                Page = originalPages,
                Items = query.Skip(page).Take(take).ToList(),
                Total = originalPages
            };

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }
    }
}
