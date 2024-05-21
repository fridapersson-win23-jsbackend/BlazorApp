namespace BlazorApp.Models.Courses;

public class CourseCardModel
{
    public string? Id { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsDigital { get; set; }
    public string? ImageUri { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public decimal? Price { get; set; }
    public decimal? DiscountedPrice { get; set; }
    public decimal? HoursToComplete { get; set; }
    public decimal? LikesInPercent { get; set; }
    public decimal? LikesInNumber { get; set; }

}
