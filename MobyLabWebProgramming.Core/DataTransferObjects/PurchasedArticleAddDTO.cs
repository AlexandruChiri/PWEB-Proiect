namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class PurchasedArticleAddDTO
{
    public Guid Id { get; set; }
    public ArticleDTO Aarticle { get; set; } = default!;
    public float Price { get; set; } = default!;
    public int Cnt { get; set; } = default!;
}