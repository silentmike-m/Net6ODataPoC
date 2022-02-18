namespace Net6ODataPoc.Application.Customers.ViewModels;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public sealed record Customer
{
    [DataMember(Name = "id")]
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.Empty;
    [DataMember(Name = "address")]
    [JsonPropertyName("address")]
    public string Address { get; init; } = string.Empty;
    [DataMember(Name = "company_name")]
    [JsonPropertyName("company_name")]
    public string CompanyName { get; init; } = string.Empty;
    [DataMember(Name = "city")]
    [JsonPropertyName("city")]
    public string City { get; init; } = string.Empty;
    [DataMember(Name = "county")]
    [JsonPropertyName("county")]
    public string County { get; init; } = string.Empty;
    [DataMember(Name = "email")]
    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;
    [DataMember(Name = "first_name")]
    [JsonPropertyName("first_name")]
    public string FirstName { get; init; } = string.Empty;
    [DataMember(Name = "last_name")]
    [JsonPropertyName("last_name")]
    public string LastName { get; init; } = string.Empty;
    [DataMember(Name = "phone")]
    [JsonPropertyName("phone")]
    public string Phone { get; init; } = string.Empty;
    [DataMember(Name = "tags")]
    [JsonPropertyName("tags")]
    public IReadOnlyList<CustomerTag> CustomerTags { get; set; } = new List<CustomerTag>().AsReadOnly();
}
