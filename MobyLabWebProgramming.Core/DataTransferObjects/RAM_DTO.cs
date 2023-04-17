namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class RAM_DTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
    public string RAM_Type { get; set; } = default!;
    public int Capacity { get; set; } = default!;
    public string Interface { get; set; } = default!;

}