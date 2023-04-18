namespace MobyLabWebProgramming.Core.Enums;

using Ardalis.SmartEnum;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;

[JsonConverter(typeof(SmartEnumNameConverter<CpuSocketEnum, string>))]
public sealed class CpuSocketEnum : SmartEnum<CpuSocketEnum, string>
{
    public static readonly CpuSocketEnum Am4 = new(nameof(Am4), "AM4");

    private CpuSocketEnum(string name, string value) : base(name, value)
    {
    }
}