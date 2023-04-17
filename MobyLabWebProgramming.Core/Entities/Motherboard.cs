using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class Motherboard : Article
{
    public int RamSlots { get; set; }
    public string RamType { get; set; }
    public int RamCapacity { get; set; }
    public string CpuSocket { get; set; }

    public Motherboard(string name, int price, string manufacturer, int ramSlots, string ramType, int ramCapacity,
        string cpuSocket) : base(name, ArticleTypeEnum.Motherboard, price, manufacturer)
    {
        RamSlots = ramSlots;
        RamType = ramType;
        RamCapacity = ramCapacity;
        CpuSocket = cpuSocket;
    }
}
