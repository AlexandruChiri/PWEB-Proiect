using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class StorageDriveDTO : ArticleDTO
{
    public StorageDriveTypeEnum DriveType { get; }
    public int Capacity { get; }
    public string Interface { get; }

    public StorageDriveDTO(StorageDrive storageDrive) : base(storageDrive)
    {
        DriveType = storageDrive.DriveType;
        Capacity = storageDrive.Capacity;
        Interface = storageDrive.Interface;
    }
}