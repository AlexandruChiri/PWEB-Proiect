using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class PurchasedArticleDTO
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public ArticleDTO Aarticle { get; set; } = default!;
    public string Name { get; set; } = default!;
    public ArticleTypeEnum Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
    public int Cnt { get; set; }
}