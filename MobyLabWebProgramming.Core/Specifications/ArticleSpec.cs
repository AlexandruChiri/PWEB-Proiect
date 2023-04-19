using Ardalis.Specification;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public class ArticleSpec : BaseSpec<ArticleSpec, Article>
{
    public ArticleSpec(Guid id) : base(id)
    {
    }

    public ArticleSpec(string name, string manufacturer)
    {
        Query.Where(e => e.Name == name && e.Manufacturer == manufacturer).Take(1);
    }
}