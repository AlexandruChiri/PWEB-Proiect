namespace MobyLabWebProgramming.Core.Entities;

public class PurchasedArticle : BaseEntity
{
    public Article Aarticle { get; set; }
    public float PricePerUnit { get; set; }
    public int Cnt { get; set; }
    public float Price { get; }

    public PurchasedArticle(AddedArticle addedArticle)
    {
        Aarticle = addedArticle.Aarticle;
        PricePerUnit = addedArticle.Aarticle.Price;
        Cnt = addedArticle.Cnt;
        Price = PricePerUnit * Cnt;
    }
}