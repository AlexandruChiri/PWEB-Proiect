using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

[JsonConverter(typeof(SmartEnumNameConverter<ArticleTypeEnum, string>))]
public sealed class ArticleTypeEnum : SmartEnum<ArticleTypeEnum, string>
{
    public static readonly ArticleTypeEnum Motherboard = new(nameof(Motherboard), "Motherboard");
    public static readonly ArticleTypeEnum Cpu = new(nameof(Cpu), "Cpu");
    public static readonly ArticleTypeEnum Ram = new(nameof(Ram), "Ram");
    public static readonly ArticleTypeEnum StorageDrive = new(nameof(StorageDrive), "StorageDrive");

    private ArticleTypeEnum(string name, string value) : base(name, value)
    {
    }
}