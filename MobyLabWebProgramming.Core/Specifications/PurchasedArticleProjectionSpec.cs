using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public class PurchasedArticleProjectionSpec : BaseSpec<PurchasedArticleProjectionSpec, PurchasedArticle, PurchasedArticleDTO>
{
    protected override Expression<Func<PurchasedArticle, PurchasedArticleDTO>> Spec => e => new()
    {
        Id = e.Id,
        Aarticle = new ArticleDTO()
        {
            Id = e.Aarticle.Id,
            Name = e.Aarticle.Name,
            Type = e.Aarticle.Type,
            Price = e.Aarticle.Price,
            Manufacturer = e.Aarticle.Manufacturer,
            Description = e.Aarticle.Description
        },
        ComandaId = e.ComandaId,
        Price = e.Price,
        Cnt = e.Cnt
    };

    public PurchasedArticleProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public PurchasedArticleProjectionSpec(Guid id) : base(id)
    {
    }

    public PurchasedArticleProjectionSpec(string? search, Guid comandaId)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";

        Query
            .Where(e => e.ComandaId.Equals(comandaId))
            .Where(e => EF.Functions.ILike(e.Aarticle.Name, searchExpr));
        // This is an example on who database specific expressions can be used via C# expressions.
        // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }

    public PurchasedArticleProjectionSpec(string? search)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";

        Query.Where(e => EF.Functions.ILike(e.Aarticle.Name, searchExpr));
        // This is an example on who database specific expressions can be used via C# expressions.
        // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }
}