namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class StorageDriveDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
    public string StorageDriveType { get; set; } = default!;
    public int Capacity { get; set; } = default!;
    public string Interface { get; set; } = default!;
}