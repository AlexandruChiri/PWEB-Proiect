namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class CosCumparaturiDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } = default!;
    public UserDTO UserDto { get; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
    public DateTime UpdatedAt { get; set; } = default!;
    public string Description { get; set; } = default!;
}