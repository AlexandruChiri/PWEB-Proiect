using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class Article : BaseEntity
{
    public string Name { get; set; } = default!;
    public ArticleTypeEnum Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
    
    public string Description { get; set; } = default!;

    // public Article(string name, ArticleTypeEnum type, int price, string manufacturer, string description)
    // {
    //     Name = name;
    //     Type = type;
    //     Price = price;
    //     Manufacturer = manufacturer;
    //     Description = description;
    // }
}
