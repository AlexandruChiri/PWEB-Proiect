namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class MotherboardDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public float Price { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
    public int RAM_Slots { get; set; } = default!;
    public string RAM_Type { get; set; } = default!;
    public int RAM_Capacity { get; set; } = default!;
    public string CPU_Socket { get; set; } = default!;
}