namespace Net6ODataPoc.Infrastructure.JsonStorage.Interfaces;

using Net6ODataPoc.Application.Customers.ViewModels;

internal interface ICustomerReadService
{
    Task<Customers> GetCustomers(CancellationToken cancellationToken = default);
}
