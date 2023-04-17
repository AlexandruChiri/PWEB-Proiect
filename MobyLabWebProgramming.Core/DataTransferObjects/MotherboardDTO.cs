using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class MotherboardDTO : ArticleDTO
{
    public int RamSlots { get; set; }
    public string RamType { get; set; }
    public int RamCapacity { get; set; }
    public string CpuSocket { get; set; }

    public MotherboardDTO(Motherboard motherboard) : base(motherboard)
    {
        RamSlots = motherboard.RamSlots;
        RamType = motherboard.RamType;
        RamCapacity = motherboard.RamCapacity;
        CpuSocket = motherboard.CpuSocket;
    }
}