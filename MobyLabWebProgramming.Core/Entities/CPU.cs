using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public abstract class Cpu : Article
{
    public float Frequency { get; set; }
    public int Cores { get; set; }
    public int Threads { get; set; }
    public int Tdp { get; set; }
    public CpuSocketEnum Socket { get; set; }
    public short Igpu { get; set; }

    public Cpu(string name, int price, string manufacturer, float frequency, int cores, int threads, int tdp,
        CpuSocketEnum socket, short iGpu) : base(name, ArticleTypeEnum.Cpu, price, manufacturer)
    {
        Frequency = frequency;
        Cores = cores;
        Threads = threads;
        Tdp = tdp;
        Socket = socket;
        Igpu = iGpu;
    }
}
