namespace Net6ODataPoc.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Net6ODataPoc.Application.Customers.Queries;
using Net6ODataPoc.Application.Customers.ViewModels;

[ApiController, Route("[controller]/[action]")]
public sealed class CustomersController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomersController(IMediator mediator) => this.mediator = mediator;

    [HttpPost(Name = "GetCustomers")]
    [EnableQuery]
    public async Task<Customers> GetCustomers()
    {
        var request = new GetCustomers();

        var result = await this.mediator.Send(request, CancellationToken.None);

        return result;
    }
}
