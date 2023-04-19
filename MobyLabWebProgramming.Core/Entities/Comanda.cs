using System.Collections;

namespace MobyLabWebProgramming.Core.Entities;

public class Comanda : BaseEntity
{
    public Guid UserId { get; set; } = default!;
    public ICollection<PurchasedArticle> PurchasedArticles { get; set; } = default!;

    public User User { get; set; } = default!;
    public float Price { get; set; } = default!;

    // public Comanda(CosCumparaturi cosCumparaturi)
    // {
    //     Price = 0;
    //     User = cosCumparaturi.User;
    //     UserId = cosCumparaturi.UserId;
    //     PurchasedArticles = new List<PurchasedArticle>();
    //     foreach (AddedArticle addedArticle in cosCumparaturi.Articles)
    //     {
    //         PurchasedArticle purchasedArticle = new PurchasedArticle(addedArticle, this);
    //         PurchasedArticles.Add(purchasedArticle);
    //         Price += purchasedArticle.Price;
    //     }
    // }
}
