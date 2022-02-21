namespace Net6ODataPoc.Infrastructure.JsonStorage.Services;
using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Options;
using Net6ODataPoc.Application.Customers.ViewModels;
using Net6ODataPoc.Domain.Entities;
using Net6ODataPoc.Infrastructure.JsonStorage.Constants;
using Net6ODataPoc.Infrastructure.JsonStorage.Interfaces;

internal sealed class CustomerReadService : ICustomerReadService
{
    private const string TAG_ID = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
    private const string TAG_NAME = "random tag name";

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

        foreach (var customer in customersList)
        {
            var tags = CreateCustomerTags(customer.FirstName, customer.Id);

            customer.CustomerTags = tags;
        }

        var result = new Customers
        {
            CustomersList = customersList,
            TotalCount = customersList.Count,
        };

        return result;
    }

    private static List<CustomerTag> CreateCustomerTags(string customerName, Guid customerId)
    {
        var tags = new List<CustomerTag>
        {
            new()
            {
                Id = customerId,
                Name = customerName,
            },
            new()
            {
                Id = Guid.Parse(TAG_ID),
                Name = TAG_NAME,
            },
        };

        return tags;
    }
}
