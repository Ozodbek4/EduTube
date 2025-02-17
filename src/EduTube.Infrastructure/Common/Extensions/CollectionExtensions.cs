using Microsoft.EntityFrameworkCore;

namespace EduTube.Infrastructure.Common.Extensions;

public static class CollectionExtensions
{
    public static IQueryable<TEntity> IncludeIf<TEntity>(this IQueryable<TEntity> source, string[]? includes) where TEntity : class
    {
        if (includes is not null)
            foreach (var include in includes)
                source.Include(include);

        return source;
    }
}