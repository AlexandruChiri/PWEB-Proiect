using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class PurchasedArticleDTO
{
    public Guid Id { get; set; }
    public ArticleDTO Aarticle { get; set; } = default!;
    public float Price { get; set; } = default!;
    public int Cnt { get; set; } = default!;
    public Guid ComandaId { get; set; }
}