using System.Net;
using MobyLabWebProgramming.Core.Constants;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations;

public class PurchasedArticleService : IPurchasedArticleService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    public PurchasedArticleService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }
    
    public async Task<ServiceResponse<PurchasedArticleDTO>> GetPurchasedArticle(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new PurchasedArticleProjectionSpec(id), cancellationToken); // Get a user using a specification on the repository.

        return result != null ? 
            ServiceResponse<PurchasedArticleDTO>.ForSuccess(result) : 
            ServiceResponse<PurchasedArticleDTO>.FromError(CommonErrors.UserNotFound); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<PurchasedArticleDTO>>> GetPurchasedArticles(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination,
            new PurchasedArticleProjectionSpec(pagination.Search), cancellationToken);
        // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse<PagedResponse<PurchasedArticleDTO>>.ForSuccess(result);
    }

    public async Task<ServiceResponse<PagedResponse<PurchasedArticleDTO>>> GetPurchasedArticles(PaginationSearchQueryParams pagination, ComandaDTO comanda, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination,
            new PurchasedArticleProjectionSpec(pagination.Search, comanda.Id), cancellationToken);
        // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse<PagedResponse<PurchasedArticleDTO>>.ForSuccess(result);
    }

    public async Task<ServiceResponse<int>> GetPurchasedArticleCount(CancellationToken cancellationToken = default) => 
        ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<PurchasedArticle>(cancellationToken));

    public async Task<ServiceResponse> DeletePurchasedArticle(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin delete the article!", ErrorCodes.CannotDelete));
        }

        await _repository.DeleteAsync<PurchasedArticle>(id, cancellationToken);
        // Delete the entity.

        return ServiceResponse.ForSuccess();
    }
}