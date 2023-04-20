using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IAddedArticleService
{
    /// <summary>
    /// GetUser will provide the information about a user given its user Id.
    /// </summary>
    public Task<ServiceResponse<AddedArticleDTO>> GetAddedArticle(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// GetUsers returns page with user information from the database.
    /// </summary>
    public Task<ServiceResponse<PagedResponse<AddedArticleDTO>>> GetAddedArticles(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    /// <summary>
    /// GetUserCount returns the number of users in the database.
    /// </summary>
    public Task<ServiceResponse<int>> GetAddedArticleCount(UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    /// <summary>
    /// AddUser adds an user and verifies if requesting user has permissions to add one.
    /// If the requesting user is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> AddAddedArticle(AddedArticleAddDTO addedArticle, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    /// <summary>
    /// UpdateUser updates an user and verifies if requesting user has permissions to update it, if the user is his own then that should be allowed.
    /// If the requesting user is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> UpdateAddedArticle(AddedArticleUpdateDTO addedArticle, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    /// <summary>
    /// DeleteUser deletes an user and verifies if requesting user has permissions to delete it, if the user is his own then that should be allowed.
    /// If the requesting user is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> DeleteAddedArticle(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
}