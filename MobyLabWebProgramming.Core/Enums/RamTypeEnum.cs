using Ardalis.SmartEnum;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;

namespace MobyLabWebProgramming.Core.Enums;

[JsonConverter(typeof(SmartEnumNameConverter<RamTypeEnum, string>))]
public sealed class RamTypeEnum : SmartEnum<RamTypeEnum, string>
{
    public static readonly RamTypeEnum Ddr1 = new(nameof(Ddr1), "Ddr1");
    public static readonly RamTypeEnum Ddr2 = new(nameof(Ddr2), "Ddr2");
    public static readonly RamTypeEnum Ddr3 = new(nameof(Ddr3), "Ddr3");
    public static readonly RamTypeEnum Ddr4 = new(nameof(Ddr4), "Ddr4");
    public static readonly RamTypeEnum Ddr5 = new(nameof(Ddr5), "Ddr5");

    private RamTypeEnum(string name, string value) : base(name, value)
    {
    }
}