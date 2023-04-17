using System.Collections;

namespace MobyLabWebProgramming.Core.Entities;

public class Comanda : BaseEntity
{
    public ICollection<PurchasedArticle> PurchasedArticles { get; }

    public User User { get; }
    public float Price { get; }

    public Comanda(CosCumparaturi cosCumparaturi)
    {
        Price = 0;
        User = cosCumparaturi.User;
        PurchasedArticles = new List<PurchasedArticle>();
        foreach (AddedArticle addedArticle in cosCumparaturi.Articles)
        {
            PurchasedArticle purchasedArticle = new PurchasedArticle(addedArticle);
            PurchasedArticles.Add(purchasedArticle);
            Price += purchasedArticle.Price;
        }
    }
}
