using Ardalis.Specification;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public class AddedArticleSpec : BaseSpec<AddedArticleSpec, AddedArticle>
{
    public AddedArticleSpec(Guid id) : base(id)
    {
    }

    public AddedArticleSpec(Guid articleId, Guid cosId)
    {
        Query.Where(e => e.CosId == cosId && e.ArticleId == articleId);
    }
}