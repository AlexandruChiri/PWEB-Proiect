namespace MobyLabWebProgramming.Core.Entities;

public class CosCumparaturi : BaseEntity
{
    public ICollection<AddedArticle> Articles { get; }
    public User User { get; }

    public CosCumparaturi(User user)
    {
        Articles = new List<AddedArticle>();
        User = user;
    }

    public int AddArticle(Article article, int cnt)
    {
        int ret;
        AddedArticle? addedArticle = Articles.FirstOrDefault(art => art.Aarticle.Id.Equals(article.Id));
        if (addedArticle == null)
        {
            addedArticle = new AddedArticle(article, cnt);
            Articles.Add(addedArticle);
            ret = cnt;
        }
        else
        {
            addedArticle.Cnt += cnt;
            ret = addedArticle.Cnt;
        }
        return ret;
    }

    public float GetPrice()
    {
        float price = 0;
        foreach (AddedArticle addedArticle in Articles)
        {
            price += addedArticle.GetPrice();
        }

        return price;
    }
}