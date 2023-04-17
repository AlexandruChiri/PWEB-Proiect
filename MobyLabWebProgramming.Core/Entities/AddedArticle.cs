namespace MobyLabWebProgramming.Core.Entities;

public class AddedArticle : BaseEntity
{
    public Article Aarticle { get; set; }
    public int Cnt { get; set; }

    public AddedArticle(Article aarticle, int cnt)
    {
        Aarticle = aarticle;
        Cnt = cnt;
    }

    public float GetPrice()
    {
        return Aarticle.Price * Cnt;
    }
}