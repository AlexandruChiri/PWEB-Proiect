using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

/// <summary>
/// This DTO is used to update a user, the properties besides the id are nullable to indicate that they may not be updated if they are null.
/// </summary>
public record ArticleUpdateDTO(Guid Id, ArticleTypeEnum? Type = default, string? Name = default, float Price = default,
    string? Manufacturer = default, string? Description = default);
