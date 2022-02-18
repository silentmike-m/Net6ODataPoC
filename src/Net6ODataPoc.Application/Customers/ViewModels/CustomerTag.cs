namespace Net6ODataPoc.Application.Customers.ViewModels;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[DataContract]
public sealed record CustomerTag
{
    [DataMember(Name = "id")]
    [JsonPropertyName("id")]
    public Guid Id { get; init; } = Guid.Empty;
    [DataMember(Name = "name")]
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;
}
