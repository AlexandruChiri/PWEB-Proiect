using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public class ComandaProjectionSpec : BaseSpec<ComandaProjectionSpec, Comanda, ComandaDTO>
{
    protected override Expression<Func<Comanda, ComandaDTO>> Spec => e => new ComandaDTO
    {
        Id = e.Id,
        User = new UserDTO()
        {
            Id = e.User.Id,
            Email = e.User.Email,
            Name = e.User.Name,
            Role = e.User.Role,
            CosId = e.User.Cos.Id
        }
    };

    public ComandaProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public ComandaProjectionSpec(Guid id) : base(id)
    {
    }

    public ComandaProjectionSpec(Guid? userId, UserDTO? _)
    {
        if (userId == null)
        {
            return;
        }

        Query.Where(e => e.UserId == userId);
    }
}