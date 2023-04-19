using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IComandaService
{
    public Task<ServiceResponse<ComandaDTO>> GetComanda(Guid id, CancellationToken cancellationToken = default);
    
    public Task<ServiceResponse<PagedResponse<ComandaDTO>>> GetComenzi(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);

    public Task<ServiceResponse<int>> GetComandaCount(CancellationToken cancellationToken = default);
    
    public Task<ServiceResponse> AddComanda(ComandaAddDTO comanda, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    
    public Task<ServiceResponse> DeleteComanda(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
}