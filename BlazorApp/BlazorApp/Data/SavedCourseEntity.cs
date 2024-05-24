namespace BlazorApp.Data;

public class SavedCourseEntity
{
    public string UserId { get; set; } = null!;
    public string CourseId { get; set; } = null!;
    public ApplicationUser? User { get; set; }

}
