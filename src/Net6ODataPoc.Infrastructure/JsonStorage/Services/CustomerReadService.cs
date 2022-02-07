namespace Net6ODataPoc.Infrastructure.JsonStorage.Services;

using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Options;
using Net6ODataPoc.Application.Customers.ViewModels;
using Net6ODataPoc.Domain.Entities;
using Net6ODataPoc.Infrastructure.JsonStorage.Constants;
using Net6ODataPoc.Infrastructure.JsonStorage.Interfaces;
using SignalRPoc.Server.Infrastructure.JsonStorage;

internal sealed class CustomerReadService : ICustomerReadService
{
    private readonly IMapper mapper;
    private readonly JsonStorageOptions options;

    public CustomerReadService(IMapper mapper, IOptions<JsonStorageOptions> options)
    {
        this.mapper = mapper;
        this.options = options.Value;
    }

    public async Task<Customers> GetCustomers(CancellationToken cancellationToken = default)
    {
        var filePath = Path.Combine(this.options.Path, JsonStorageFileNames.CUSTOMERS_FILE_NAME);

        var json = await File.ReadAllTextAsync(filePath, Encoding.UTF8, cancellationToken);

        var customers = JsonSerializer.Deserialize<List<CustomerEntity>>(json);

        var customersList = this.mapper.Map<IReadOnlyList<Customer>>(customers);

        var result = new Customers
        {
            CustomersList = customersList,
        };

        return result;
    }
}
