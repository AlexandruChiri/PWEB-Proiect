using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers;

public class PurchasedArticleController : AuthorizedController
{
    private readonly IPurchasedArticleService _purchasedArticleService;
    
    public PurchasedArticleController(IPurchasedArticleService purchasedArticleService, IUserService userService) : base(userService)
    {
        _purchasedArticleService = purchasedArticleService;
    }
    
    // [Authorize] // You need to use this attribute to protect the route access, it will return a Forbidden status code if the JWT is not present or invalid, and also it will decode the JWT token.
    // [HttpGet("{id:guid}")] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetById/<some_guid>.
    // public async Task<ActionResult<RequestResponse<PurchasedArticleDTO>>> GetById([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    // {
    //     var currentUser = await GetCurrentUser();
    //
    //     return currentUser.Result != null ? 
    //         this.FromServiceResponse(await _purchasedArticleService.GetPurchasedArticle(id)) : 
    //         this.ErrorMessageResult<PurchasedArticleDTO>(currentUser.Error);
    // }
    // LAFEL CA LA COMANDA
    // public async Task<ActionResult<RequestResponse<ComandaDTO>>> GetById([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    // {
    //     var currentUser = await GetCurrentUser();
    //
    //     return currentUser.Result != null ? 
    //         this.FromServiceResponse(await _comandaService.GetComanda(id)) : 
    //         this.ErrorMessageResult<ComandaDTO>(currentUser.Error);
    // }
    
    [Authorize]
    [HttpGet] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetPage.
    public async Task<ActionResult<RequestResponse<PagedResponse<PurchasedArticleDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination) // The FromQuery attribute will bind the parameters matching the names of
        // the PaginationSearchQueryParams properties to the object in the method parameter.
    {
        var currentUser = await GetCurrentUser();
    
        return currentUser.Result != null ?
            this.FromServiceResponse(await _purchasedArticleService.GetPurchasedArticles(pagination)) :
            this.ErrorMessageResult<PagedResponse<PurchasedArticleDTO>>(currentUser.Error);
    }
    // LAFEL CA LA COMANDA
    // public async Task<ActionResult<RequestResponse<PagedResponse<ComandaDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination) // The FromQuery attribute will bind the parameters matching the names of
    //     // the PaginationSearchQueryParams properties to the object in the method parameter.
    // {
    //     var currentUser = await GetCurrentUser();
    //
    //     return currentUser.Result != null ?
    //         this.FromServiceResponse(await _comandaService.GetComenzi(pagination)) :
    //         this.ErrorMessageResult<PagedResponse<ComandaDTO>>(currentUser.Error);
    // }
    
    // [Authorize]
    // [HttpDelete("{id:guid}")] // This attribute will make the controller respond to a HTTP DELETE request on the route /api/User/Delete/<some_guid>.
    public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    {
        var currentUser = await GetCurrentUser();
    
        return currentUser.Result != null ?
            this.FromServiceResponse(await _purchasedArticleService.DeletePurchasedArticle(id, currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }
    // LAFEL CA LA COMANDA!!!
    // public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    // {
    //     var currentUser = await GetCurrentUser();
    //
    //     return currentUser.Result != null ?
    //         this.FromServiceResponse(await _comandaService.DeleteComanda(id, currentUser.Result)) :
    //         this.ErrorMessageResult(currentUser.Error);
    // }
}