using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class RamDTO : ArticleDTO
{
    public RamTypeEnum RamType { get; set; } = default!;
    public int Capacity { get; set; } = default!;
    public int Frequency { get; set; } = default!;

    public RamDTO(Ram ram) : base(ram)
    {
        RamType = ram.RamType;
        Capacity = ram.Capacity;
        Frequency = ram.Frequency;
    }
}