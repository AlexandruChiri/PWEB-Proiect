using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class AddedArticleProjectionSpec : BaseSpec<AddedArticleProjectionSpec, AddedArticle, AddedArticleDTO>
{
    protected override Expression<Func<AddedArticle, AddedArticleDTO>> Spec => e => new AddedArticleDTO
    {
        Id = e.Id,
        ArticleId = e.ArticleId,
        Aarticle = new ArticleDTO()
        {
            Id = e.Aarticle.Id,
            Name = e.Aarticle.Name,
            Type = e.Aarticle.Type,
            Price = e.Aarticle.Price,
            Manufacturer = e.Aarticle.Manufacturer,
            Description = e.Aarticle.Description
        },
        Cnt = e.Cnt,
        CosId = e.CosId
    };

    public AddedArticleProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public AddedArticleProjectionSpec(Guid id) : base(id)
    {
    }
    public AddedArticleProjectionSpec(string? search)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";

        Query
            .Where(e => EF.Functions.ILike(e.Aarticle.Name, searchExpr));
        // This is an example on who database specific expressions can be used via C# expressions.
        // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }

    public AddedArticleProjectionSpec(string? search, Guid cosId)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";

        Query
            .Where(e => e.CosId.Equals(cosId))
            .Where(e => EF.Functions.ILike(e.Aarticle.Name, searchExpr));
        // This is an example on who database specific expressions can be used via C# expressions.
        // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }
    
    public AddedArticleProjectionSpec(Guid cosId, UserDTO _)
    {
        Query
            .Where(e => e.CosId.Equals(cosId));
        // This is an example on who database specific expressions can be used via C# expressions.
        // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }
}