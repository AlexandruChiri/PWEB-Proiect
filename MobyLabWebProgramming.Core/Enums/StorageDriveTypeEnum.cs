using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

[JsonConverter(typeof(SmartEnumNameConverter<StorageDriveTypeEnum, string>))]
public sealed class StorageDriveTypeEnum : SmartEnum<StorageDriveTypeEnum, string>
{
    public static readonly StorageDriveTypeEnum HDD = new(nameof(HDD), "HDD");
    public static readonly StorageDriveTypeEnum SSD = new(nameof(SSD), "SSD");

    private StorageDriveTypeEnum(string name, string value) : base(name, value)
    {
    }
}
