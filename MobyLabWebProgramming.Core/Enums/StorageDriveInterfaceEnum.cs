using Ardalis.SmartEnum;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;

namespace MobyLabWebProgramming.Core.Enums;

[JsonConverter(typeof(SmartEnumNameConverter<StorageDriveInterfaceEnum, string>))]
public class StorageDriveInterfaceEnum : SmartEnum<StorageDriveInterfaceEnum, string>
{
    public static readonly StorageDriveInterfaceEnum UsbC = new(nameof(UsbC), "USB-C");
    public static readonly StorageDriveInterfaceEnum Sata = new(nameof(Sata), "Sata");

    private StorageDriveInterfaceEnum(string name, string value) : base(name, value)
    {
    }
}