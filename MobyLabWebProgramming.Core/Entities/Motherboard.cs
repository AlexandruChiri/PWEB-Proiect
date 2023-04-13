namespace MobyLabWebProgramming.Core.Entities;

public class Motherboard
{
    public string Name { get; set; } = default!;
    public int RAM_Slots { get; set; } = default!;
    public string RAM_Type { get; set; } = default!;
    public int RAM_Capacity { get; set; } = default!;
    public string CPU_Socket { get; set; } = default!;
}
