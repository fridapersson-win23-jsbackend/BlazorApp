namespace BlazorApp.Models.GraphQL;

public class GraphQLQuery
{
    public string Query { get; set; } = null!;
    public object? Variables { get; set; }
}
