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

public class ArticleService : IArticleService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public ArticleService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }
    
    public async Task<ServiceResponse<ArticleDTO>> GetArticle(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new ArticleProjectionSpec(id), cancellationToken); // Get a Article using a specification on the repository.
        
                return result != null ? 
                    ServiceResponse<ArticleDTO>.ForSuccess(result) : 
                    ServiceResponse<ArticleDTO>.FromError(CommonErrors.ArticleNotFound); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<ArticleDTO>>> GetArticles(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new ArticleProjectionSpec(pagination.Search), cancellationToken); // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse<PagedResponse<ArticleDTO>>.ForSuccess(result);
    }

    public async Task<ServiceResponse<int>> GetArticleCount(CancellationToken cancellationToken = default) => 
        ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<Article>(cancellationToken)); // Get the count of all article entities in the database.

    public async Task<ServiceResponse> AddArticle(ArticleAddDTO article, UserDTO? requestingUser = default,
        CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add articles!", ErrorCodes.CannotAdd));
        }
        
        await _repository.AddAsync(new Article
        {
            Name = article.Name,
            Type = article.Type,
            Price = article.Price,
            Manufacturer = article.Manufacturer,
            Description = article.Description
        }, cancellationToken); // A new entity is created and persisted in the database.
        
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateArticle(ArticleUpdateDTO article, UserDTO? requestingUser = default,
        CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the article
                {
                    return ServiceResponse.FromError(new(HttpStatusCode.Forbidden,
                        "Only the admin can update an article!", ErrorCodes.CannotUpdate));
                }
        
                var entity = await _repository.GetAsync(new ArticleSpec(article.Id), cancellationToken);
        
                if (entity != null) // Verify if the article is not found, you cannot update an non-existing entity.
                {
                    entity.Name = article.Name ?? entity.Name;
                    entity.Type = article.Type ?? entity.Type;
                    if (article.Price <= 0)
                        entity.Price = article.Price;
                    entity.Manufacturer = article.Manufacturer ?? entity.Manufacturer;
                    entity.Description = article.Description ?? entity.Description;
        
                    await _repository.UpdateAsync(entity, cancellationToken); // Update the entity and persist the changes.
                }
        
                return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteArticle(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can delete the article
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can delete an article!", ErrorCodes.CannotDelete));
        }

        await _repository.DeleteAsync<Article>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }
}