using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class Ram : Article
{
    public string RamType { get; set; }
    public int Capacity { get; set; }
    public int Frequency { get; set; }
    
    public Ram(string name, int price, string manufacturer, string ramType, int capacity, int frequency) :
        base(name, ArticleTypeEnum.Ram, price, manufacturer)
    {
        RamType = ramType;
        Capacity = capacity;
        Frequency = frequency;
    }
}
