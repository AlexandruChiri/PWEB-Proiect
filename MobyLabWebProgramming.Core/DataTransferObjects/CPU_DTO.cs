using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class CpuDto : ArticleDTO
{
    public float Frequency { get; }
    public int Cores { get; }
    public int Threads { get; }
    public int Tdp { get; }
    public CpuSocketEnum Socket { get; }
    public short Igpu { get; }

    public CpuDto(Cpu cpu) : base(cpu)
    {
        Frequency = cpu.Frequency;
        Cores = cpu.Cores;
        Threads = cpu.Threads;
        Tdp = cpu.Tdp;
        Socket = cpu.Socket;
        Igpu = cpu.Igpu;
    }
}
