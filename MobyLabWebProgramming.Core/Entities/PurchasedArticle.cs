namespace MobyLabWebProgramming.Core.Entities;

public class PurchasedArticle : BaseEntity
{
    public Guid ComandaId { get; set; }
    public Guid ArticleId { get; set; }
    public Article Aarticle { get; set; }
    public float PricePerUnit { get; set; }
    public int Cnt { get; set; }
    public float Price { get; }

    public PurchasedArticle(AddedArticle addedArticle, Comanda comanda)
    {
        ComandaId = comanda.Id;
        ArticleId = addedArticle.Id;
        Aarticle = addedArticle.Aarticle;
        PricePerUnit = addedArticle.Aarticle.Price;
        Cnt = addedArticle.Cnt;
        Price = PricePerUnit * Cnt;
    }
}