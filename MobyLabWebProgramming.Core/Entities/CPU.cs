namespace MobyLabWebProgramming.Core.Entities;

public class CPU
{
    public float Frequency { get; set; } = default!;
    public int Cores { get; set; } = default!;
    public int Threads { get; set; } = default!;
    public int Tdp { get; set; } = default!;
    public string Socket { get; set; } = default!;
    public bool IGPU { get; set; } = default!;
}
