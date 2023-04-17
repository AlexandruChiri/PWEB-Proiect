namespace MobyLabWebProgramming.Core.Entities;

public class RAM : Article
{
    public string Type { get; set; } = default!;
    public float Capacity { get; set; } = default!;
    public int Frequency { get; set; } = default!;
}
