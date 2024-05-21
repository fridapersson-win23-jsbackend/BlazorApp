using BlazorProject.Models;

public class CourseModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public int? StarRating { get; set; }
    public string? Reviews { get; set; }
    public string? LikesInNumber { get; set; }
    public string? LikesInPercent { get; set; }
    public decimal HoursToComplete { get; set; }
    public ImageModel? Image { get; set; }
    public Prices? Prices { get; set; }
    public bool IsDigital { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsSaved { get; set; }


    public Category? Category { get; set; }
    public Author? Author { get; set; }
    public Content? Content { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string? CategoryName { get; set; }
}

public class Author
{
    //public int Id { get; set; }
    //public string? AuthorTitle { get; set; }
    public string? AuthorName { get; set; }
    //public string? AuthorImageUrl { get; set; }
    //public string? AuthorDescription { get; set; }
    //public decimal YoutubeSubs { get; set; }
    //public decimal FacebookSubs { get; set; }
}

public class Prices
{
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
    public string? Currency { get; set; }
}

public class Content
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public ProgramDetails? ProgramDetails { get; set; }
}

public class ProgramDetails
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
