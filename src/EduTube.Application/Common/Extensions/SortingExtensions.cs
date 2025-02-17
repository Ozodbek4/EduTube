using EduTube.Application.Common.Exceptions;
using EduTube.Application.Common.Models;
using System.Linq.Expressions;

namespace EduTube.Application.Common.Extensions;

public static class SortingExtensions
{
    public static IQueryable<TEntity> SortBy<TEntity>(this IQueryable<TEntity> source, SortingParameters? sorting)
    {
        if (sorting is null || sorting.SortBy is null || sorting.SortType is null)
            return source;

        var expression = source.Expression;
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        MemberExpression selector;
        try
        {
            selector = Expression.PropertyOrField(parameter, sorting.SortBy!);
        }
        catch
        {
            throw new ArgumentIsNotValidException("Specified property is not found");
        }

        var method = string.Equals(sorting?.SortType ?? "asc", "desc", StringComparison.OrdinalIgnoreCase) ? "OrderByDescending" : "OrderBy";

        expression = Expression.Call(typeof(Queryable), method,
            new Type[] { source.ElementType, selector.Type },
            expression, Expression.Quote(Expression.Lambda(selector, parameter)));

        return source.Provider.CreateQuery<TEntity>(expression);
    }
}