using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class CpuDto : ArticleDTO
{
    public float Frequency { get; }
    public int Cores { get; }
    public int Threads { get; }
    public int Tdp { get; }
    public string Socket { get; }
    public bool Igpu { get; }

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
