using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IArticleService
{
    /// <summary>
    /// GetArticle will provide the information about a article given its article Id.
    /// </summary>
    public Task<ServiceResponse<ArticleDTO>> GetArticle(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// GetArticles returns page with article information from the database.
    /// </summary>
    public Task<ServiceResponse<PagedResponse<ArticleDTO>>> GetArticles(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// GetArticleCount returns the number of articles in the database.
    /// </summary>
    public Task<ServiceResponse<int>> GetArticleCount(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// AddArticle adds an article and verifies if requesting article has permissions to add one.
    /// If the requesting article is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> AddArticle(ArticleAddDTO article, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// UpdateArticle updates an article and verifies if requesting user has permissions to update it, if the user is an admin then that should be allowed.
    /// If the requesting user and requested article is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> UpdateArticle(ArticleUpdateDTO article, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// DeleteArticle deletes an article and verifies if requesting user has permissions to delete it
    /// If the requesting user is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> DeleteArticle(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
}