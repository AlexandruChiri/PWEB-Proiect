using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class Article : BaseEntity
{
    public string Name { get; set; }
    public ArticleTypeEnum Type { get; set; }
    public float Price { get; set; }
    public string Manufacturer { get; set; }

    public Article(string name, ArticleTypeEnum type, int price, string manufacturer)
    {
        Name = name;
        Type = type;
        Price = price;
        Manufacturer = manufacturer;
    }
}
