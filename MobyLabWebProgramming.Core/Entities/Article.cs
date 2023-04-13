namespace MobyLabWebProgramming.Core.Entities;

public class Article : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
}
