using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers;

public class ArticleController : AuthorizedController
{
    private readonly IArticleService _articleService;
    
    public ArticleController(IArticleService articleService, IUserService userService) : base(userService)
    {
        _articleService = articleService;
    }
    
    [Authorize] // You need to use this attribute to protect the route access, it will return a Forbidden status code if the JWT is not present or invalid, and also it will decode the JWT token.
    [HttpGet("{id:guid}")] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetById/<some_guid>.
    public async Task<ActionResult<RequestResponse<ArticleDTO>>> GetById([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    {
        return this.FromServiceResponse(await _articleService.GetArticle(id));
    }
    
    [Authorize]
    [HttpGet] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetPage.
    public async Task<ActionResult<RequestResponse<PagedResponse<ArticleDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination) // The FromQuery attribute will bind the parameters matching the names of
        // the PaginationSearchQueryParams properties to the object in the method parameter.
    {
        return this.FromServiceResponse(await _articleService.GetArticles(pagination));
    }
    
    [Authorize]
    [HttpPost] // This attribute will make the controller respond to a HTTP POST request on the route /api/User/Add.
    public async Task<ActionResult<RequestResponse>> Add([FromBody] ArticleAddDTO article)
    {
        var currentUser = await GetCurrentUser();
    
        return currentUser.Result != null ?
            this.FromServiceResponse(await _articleService.AddArticle(article, currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }
    // AM FACUT LAFEL CA LA COMANA :(((
    // {
    //     var currentUser = await GetCurrentUser();
    //
    //     return currentUser.Result != null ?
    //         this.FromServiceResponse(await _comandaService.AddComanda(comanda, currentUser.Result)) :
    //         this.ErrorMessageResult(currentUser.Error);
    // }
    
    [Authorize]
    [HttpPut] // This attribute will make the controller respond to a HTTP PUT request on the route /api/User/Update.
    public async Task<ActionResult<RequestResponse>> Update([FromBody] ArticleUpdateDTO article) // The FromBody attribute indicates that the parameter is deserialized from the JSON body.
    {
        var currentUser = await GetCurrentUser();
    
        return currentUser.Result != null ?
            this.FromServiceResponse(await _articleService.UpdateArticle(article, currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }
    
    [Authorize]
    [HttpDelete("{id:guid}")] // This attribute will make the controller respond to a HTTP DELETE request on the route /api/User/Delete/<some_guid>.
    public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    {
        var currentUser = await GetCurrentUser();
    
        return currentUser.Result != null ?
            this.FromServiceResponse(await _articleService.DeleteArticle(id, currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }
}