namespace MobyLabWebProgramming.Core.Entities;

public class StorageDrive : Article
{
    public string Type { get; set; } = default!;
    public int Capacity { get; set; } = default!;
    public string Interface { get; set; } = default!;
}
