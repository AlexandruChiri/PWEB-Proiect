using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public abstract class Cpu : Article
{
    public float Frequency { get; set; }
    public int Cores { get; set; }
    public int Threads { get; set; }
    public int Tdp { get; set; }
    public string Socket { get; set; }
    public bool Igpu { get; set; }

    public Cpu(string name, int price, string manufacturer, float frequency, int cores, int threads, int tdp,
        string socket, bool iGpu) : base(name, ArticleTypeEnum.Cpu, price, manufacturer)
    {
        Frequency = frequency;
        Cores = cores;
        Threads = threads;
        Tdp = tdp;
        Socket = socket;
        Igpu = iGpu;
    }
}
