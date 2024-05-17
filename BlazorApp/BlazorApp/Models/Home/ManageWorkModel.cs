namespace BlazorProject.Models.Home;

public class ManageWorkModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public List<string>? Bullets { get; set; }
    public ImageModel? Image { get; set; }
    public LinkModel? Link { get; set; }
}
