namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class CPU_DTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
    public float Frequency { get; set; } = default!;
    public int Cores { get; set; } = default!;
    public int Threads { get; set; } = default!;
    public int Tdp { get; set; } = default!;
    public string Socket { get; set; } = default!;
    public bool IGPU { get; set; } = default!;
}