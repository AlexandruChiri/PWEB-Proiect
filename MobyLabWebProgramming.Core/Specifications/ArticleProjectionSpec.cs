using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class ArticleProjectionSpec : BaseSpec<ArticleProjectionSpec, Article, ArticleDTO>
{
    protected override Expression<Func<Article, ArticleDTO>> Spec => e => new()
    {
        Id = e.Id,
        Name = e.Name,
        Type = e.Type,
        Price = e.Price,
        Manufacturer = e.Manufacturer,
        Description = e.Description
    };

    public ArticleProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public ArticleProjectionSpec(Guid id) : base(id)
    {
    }

    public ArticleProjectionSpec(string? search)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";

        Query.Where(e => EF.Functions.ILike(e.Name, searchExpr)); // This is an example on who database specific expressions can be used via C# expressions.
        // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }

    public ArticleProjectionSpec(string? type, float minPrice, float maxPrice)
    {
        type = !string.IsNullOrWhiteSpace(type) ? type.Trim() : null;

        if (type == null)
        {
            return;
        }

        var searchType = $"%{type.Replace(" ", "%")}%";

        Query.Include(e => EF.Functions.ILike(e.Name, searchType));
    }
}