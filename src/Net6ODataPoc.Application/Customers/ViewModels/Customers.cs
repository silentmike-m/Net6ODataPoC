namespace Net6ODataPoc.Application.Customers.ViewModels;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public sealed record Customers
{
    [DataMember(Name = "customers")]
    [JsonPropertyName("customers")]
    public IReadOnlyList<Customer> CustomersList { get; init; } = new List<Customer>().AsReadOnly();
}
