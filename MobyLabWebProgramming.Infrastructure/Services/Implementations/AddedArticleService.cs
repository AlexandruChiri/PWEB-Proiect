using MobyLabWebProgramming.Core.DataTransferObjects;
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

    public async Task<ServiceResponse<PagedResponse<AddedArticleDTO>>> GetAddedArticles(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<int>> GetAddedArticleCount(UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse> AddAddedArticle(AddedArticleAddDTO addedArticle, UserDTO? requestingUser = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse> UpdateAddedArticle(AddedArticleUpdateDTO user, UserDTO? requestingUser = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse> DeleteAddedArticle(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}