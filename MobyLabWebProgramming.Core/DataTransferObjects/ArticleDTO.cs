using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ArticleDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public ArticleTypeEnum Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;

    public ArticleDTO(Article article)
    {
        Id = article.Id;
        Name = article.Name;
        Type = article.Type;
        Price = article.Price;
        Manufacturer = article.Manufacturer;
    }
}