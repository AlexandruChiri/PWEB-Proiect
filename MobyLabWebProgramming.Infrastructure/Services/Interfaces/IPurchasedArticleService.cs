using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IPurchasedArticleService
{
    public Task<ServiceResponse<PurchasedArticleDTO>> GetPurchasedArticle(Guid id, CancellationToken cancellationToken = default);

    public Task<ServiceResponse<PagedResponse<PurchasedArticleDTO>>> GetPurchasedArticles(
        PaginationSearchQueryParams pagination, ComandaDTO comanda, CancellationToken cancellationToken = default);

    public Task<ServiceResponse<PagedResponse<PurchasedArticleDTO>>> GetPurchasedArticles(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);

    public Task<ServiceResponse<int>> GetPurchasedArticleCount(CancellationToken cancellationToken = default);
    
    public Task<ServiceResponse> DeletePurchasedArticle(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
}