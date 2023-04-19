namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ComandaAddDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } = default!;
    public UserDTO User { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
    public DateTime UpdatedAt { get; set; } = default!;
    public string Description { get; set; } = default!;
}