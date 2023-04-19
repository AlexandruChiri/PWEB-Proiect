namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ComandaDTO
{
    public Guid Id { get; set; }
    public UserDTO User { get; set; } = default!;
}