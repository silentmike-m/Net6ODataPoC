namespace Net6ODataPoc.Application.Customers.ViewModels;

using System.Text.Json.Serialization;

public sealed record Customers
{
    [JsonPropertyName("customers")] public IReadOnlyList<Customer> CustomersList { get; init; } = new List<Customer>().AsReadOnly();

}
