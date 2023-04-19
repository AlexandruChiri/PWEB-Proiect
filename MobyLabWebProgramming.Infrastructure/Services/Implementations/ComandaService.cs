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

public class ComandaService : IComandaService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;
    private readonly IMailService _mailService;

    public ComandaService(IRepository<WebAppDatabaseContext> repository, IMailService mailService)
    {
        _repository = repository;
        _mailService = mailService;
    }

    public async Task<ServiceResponse<ComandaDTO>> GetComanda(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new ComandaProjectionSpec(id), cancellationToken); // Get an order using a specification on the repository.

        return result != null ? 
            ServiceResponse<ComandaDTO>.ForSuccess(result) : 
            ServiceResponse<ComandaDTO>.FromError(CommonErrors.UserNotFound); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<ComandaDTO>>> GetComenzi(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination,
            new ComandaProjectionSpec(), cancellationToken);
        // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse<PagedResponse<ComandaDTO>>.ForSuccess(result);
    }

    public async Task<ServiceResponse<int>> GetComandaCount(CancellationToken cancellationToken = default) => 
        ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<Comanda>(cancellationToken));
    
    public async Task<ServiceResponse> AddComanda(ComandaAddDTO comanda, UserDTO? requestingUser = default,
        CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin && requestingUser.Id != comanda.UserId) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin and own user can place orders!", ErrorCodes.CannotAdd));
        }

        User? user = await _repository.GetAsync(new UserSpec(comanda.UserId), cancellationToken);

        if (user == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "The owner user doesn't exist!", ErrorCodes.UserAlreadyExists));
        }

        Comanda newComanda = new Comanda()
        {
            UserId = comanda.UserId,
            User = user,
            Price = 0
        };
        
        await _repository.AddAsync(newComanda, cancellationToken);
        
        float price = 0;
        foreach (AddedArticle addedArticle in user.Cos.Articles)
        {
            PurchasedArticle purchasedArticle = new PurchasedArticle(addedArticle, newComanda);
            price += purchasedArticle.Price;
            await _repository.AddAsync(purchasedArticle, cancellationToken);
            await _repository.DeleteAsync<AddedArticle>(addedArticle.Id, cancellationToken);
        }

        // Retin pretul comenzii
        newComanda.Price = price;
        await _repository.UpdateAsync(newComanda, cancellationToken);
        
        await _mailService.SendMail(user.Email, "Your order was placed!", MailTemplates.PlaceOrderTemplate(user.Name), true, "My App", cancellationToken); // You can send a notification on the user email. Change the email if you want.

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteComanda(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin delete the order!", ErrorCodes.CannotDelete));
        }

        await _repository.DeleteAsync<Comanda>(id, cancellationToken);
        // Delete the entity.

        return ServiceResponse.ForSuccess();
    }
}