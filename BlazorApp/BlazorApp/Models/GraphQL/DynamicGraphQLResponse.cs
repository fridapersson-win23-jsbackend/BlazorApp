using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp.Models.GraphQL;

public class DynamicGraphQLResponse
{
    [JsonPropertyName("data")]
    public JsonElement Data { get; set; }
}
