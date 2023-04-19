using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class MotherboardDTO : ArticleDTO
{
    public int RamSlots { get; }
    public RamTypeEnum RamType { get; }
    public int RamCapacity { get; }
    public CpuSocketEnum CpuSocket { get; }

    public MotherboardDTO(Motherboard motherboard) : base(motherboard)
    {
        RamSlots = motherboard.RamSlots;
        RamType = motherboard.RamType;
        RamCapacity = motherboard.RamCapacity;
        CpuSocket = motherboard.CpuSocket;
    }
}