namespace Net6ODataPoc.Application.Customers.Queries;

using MediatR;
using Net6ODataPoc.Application.Customers.ViewModels;

public sealed record GetCustomers : IRequest<Customers>
{

}
