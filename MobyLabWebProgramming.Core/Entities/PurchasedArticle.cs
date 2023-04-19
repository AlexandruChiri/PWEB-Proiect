namespace MobyLabWebProgramming.Core.Entities;

public class PurchasedArticle : BaseEntity
{
    public Guid ComandaId { get; set; }
    public Guid ArticleId { get; set; }
    public Article Aarticle { get; set; } = default!;
    public float PricePerUnit { get; set; } = default!;
    public int Cnt { get; set; } = default!;
    public float Price { get; } = default!;

    // public PurchasedArticle(AddedArticle addedArticle, Comanda comanda)
    // {
    //     ComandaId = comanda.Id;
    //     ArticleId = addedArticle.Id;
    //     Aarticle = addedArticle.Aarticle;
    //     PricePerUnit = addedArticle.Aarticle.Price;
    //     Cnt = addedArticle.Cnt;
    //     Price = PricePerUnit * Cnt;
    // }
}