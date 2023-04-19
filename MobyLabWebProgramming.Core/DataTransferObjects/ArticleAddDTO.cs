using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ArticleAddDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public ArticleTypeEnum Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
    public string Description { get; set; } = default!;
}