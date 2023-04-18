using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class Motherboard : Article
{
    public int RamSlots { get; set; }
    public RamTypeEnum RamType { get; set; }
    public int RamCapacity { get; set; }
    public CpuSocketEnum CpuSocket { get; set; }

    public Motherboard(string name, int price, string manufacturer, int ramSlots, RamTypeEnum ramType, int ramCapacity,
        CpuSocketEnum cpuSocket) : base(name, ArticleTypeEnum.Motherboard, price, manufacturer)
    {
        RamSlots = ramSlots;
        RamType = ramType;
        RamCapacity = ramCapacity;
        CpuSocket = cpuSocket;
    }
}
