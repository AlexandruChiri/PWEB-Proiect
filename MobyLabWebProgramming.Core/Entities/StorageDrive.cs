using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class StorageDrive : Article
{
    public StorageDriveTypeEnum DriveType { get; set; }
    public int Capacity { get; set; }
    public StorageDriveInterfaceEnum Interface { get; set; }

    public StorageDrive(string name, int price, string manufacturer, StorageDriveTypeEnum driveType, int capacity, StorageDriveInterfaceEnum iinterface)
        : base(name, ArticleTypeEnum.StorageDrive, price, manufacturer)
    {
        DriveType = driveType;
        Capacity = capacity;
        Interface = iinterface;
    }
}

