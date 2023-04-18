using System.Diagnostics;

namespace MobyLabWebProgramming.Core.Entities;

public class AddedArticle : BaseEntity
{
    public Guid CosId { get; set; }
    public Guid ArticleId { get; set; }
    public Article Aarticle { get; set; }
    public int Cnt { get; set; }

    public AddedArticle(Article aarticle, int cnt, CosCumparaturi cosCumparaturi)
    {
        CosId = cosCumparaturi.Id;
        Debug.Assert(Aarticle != null, nameof(Aarticle) + " != null");
        ArticleId = Aarticle.Id;
        Aarticle = aarticle;
        Cnt = cnt;
    }

    public float GetPrice()
    {
        return Aarticle.Price * Cnt;
    }
}