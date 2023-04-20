using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class AddedArticleDTO
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public ArticleDTO Aarticle { get; set; } = default!;
    public int Cnt { get; set; }
    public Guid CosId { get; set; }
}