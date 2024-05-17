using BlazorProject.Models;
using BlazorProject.Models.Generic;

namespace BlazorProject.Models.Home;

public class DownloadOurAppModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public ImageModel Image { get; set; } = null!;
    public string? Apple { get; set; }
    public string? Google { get; set; }
    public int? AppleRating { get; set; }
    public int? GoogleRating { get; set; }

    public List<FeatureBoxModel>? BoxModels { get; set; } = null!;
}
