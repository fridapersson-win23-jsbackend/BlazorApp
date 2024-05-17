using BlazorProject.Models.Generic;

namespace BlazorProject.Models.Home;

public class FeaturesModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string Description { get; set; } = null!;
    public HashSet<FeatureBoxModel> FeaturesBox { get; set; } = null!;
}
