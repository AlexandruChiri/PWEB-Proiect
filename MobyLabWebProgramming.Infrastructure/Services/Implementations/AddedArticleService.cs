using System.Net;
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

public class AddedArticleService : IAddedArticleService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;
    private IAddedArticleService _addedArticleServiceImplementation;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public AddedArticleService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }
    
    public async Task<ServiceResponse<AddedArticleDTO>> GetAddedArticle(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new AddedArticleProjectionSpec(id), cancellationToken); // Get a user using a specification on the repository.

        return result != null ? 
            ServiceResponse<AddedArticleDTO>.ForSuccess(result) : 
            ServiceResponse<AddedArticleDTO>.FromError(CommonErrors.AddedArticleNotFound); // Pack the result or error into a ServiceResponse.
    }
    
    public async Task<ServiceResponse<int>> GetAddedArticleCount(UserDTO? requestingUser = default, CancellationToken cancellationToken = default) => 
        ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<AddedArticle>(cancellationToken)); // Get the count of all user entities in the database.

    public async Task<ServiceResponse<PagedResponse<AddedArticleDTO>>> GetAddedArticles(
        PaginationSearchQueryParams pagination, UserDTO? requestingUser = default,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new AddedArticleProjectionSpec(pagination.Search, requestingUser.CosId), cancellationToken); // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse<PagedResponse<AddedArticleDTO>>.ForSuccess(result);
    }
    
    public async Task<ServiceResponse> AddAddedArticle(AddedArticleAddDTO addedArticle, UserDTO? requestingUser = default,
        CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.CosId == addedArticle.CosId) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the user owning the cart can add articles in it!", ErrorCodes.CannotAdd));
        }

        AddedArticle? result = await _repository.GetAsync(new AddedArticleSpec(addedArticle.CosId, addedArticle.ArticleId), cancellationToken);

        if (result != null)
        {
            result.Cnt += addedArticle.Cnt;
            await _repository.UpdateAsync(result, cancellationToken); // Update the entity and persist the changes.
            return ServiceResponse.ForSuccess();
        }

        await _repository.AddAsync(new AddedArticle()
        {
            CosId = addedArticle.CosId,
            ArticleId = addedArticle.ArticleId,
            Cnt = addedArticle.Cnt
        }, cancellationToken); // A new entity is created and persisted in the database.
        
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateAddedArticle(AddedArticleUpdateDTO addedArticle, UserDTO? requestingUser = default,
        CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin && requestingUser.CosId != addedArticle.CosId) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin or the own user can update the added article!", ErrorCodes.CannotUpdate));
        }

        AddedArticle? entity = await _repository.GetAsync(new AddedArticleSpec(addedArticle.Id), cancellationToken); 

        if (entity != null) // Verify if the added article is not found, you cannot update an non-existing entity.
        {
            if (addedArticle.Cnt > 0)
                entity.Cnt = addedArticle.Cnt;
            
            await _repository.UpdateAsync(entity, cancellationToken); // Update the entity and persist the changes.
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteAddedArticle(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin && requestingUser.Id != id) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden,
                "Only the admin or the owner user can delete the added article!", ErrorCodes.CannotDelete));
        }

        AddedArticle? result = await _repository.GetAsync<AddedArticle>(id, cancellationToken);

        if (result == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Added article couldn't be found!", ErrorCodes.CannotDelete));
        }

        if (requestingUser != null && result.CosId != requestingUser.CosId)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin or the owner user can delete the added article!", ErrorCodes.CannotDelete));
        }

        await _repository.DeleteAsync<AddedArticle>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }
}