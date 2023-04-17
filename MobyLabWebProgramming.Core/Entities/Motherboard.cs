namespace MobyLabWebProgramming.Core.Entities;

public class Motherboard : Article
{
    public int RAM_Slots { get; set; } = default!;
    public string RAM_Type { get; set; } = default!;
    public int RAM_Capacity { get; set; } = default!;
    public string CPU_Socket { get; set; } = default!;
}
