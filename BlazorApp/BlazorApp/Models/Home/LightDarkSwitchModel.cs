namespace BlazorProject.Models.Home;

public class LightDarkSwitchModel
{
    public string? Id { get; set; }
    public string? LightTitle { get; set; }
    public string? DarkTitle { get; set; }
    public ImageModel Image { get; set; } = null!;
}
