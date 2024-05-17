namespace BlazorProject.Models.Generic;

public class FeatureBoxModel
{
    public ImageModel FeaturesImg { get; set; } = null!;
    public string? FeaturesTitle { get; set; }
    public string FeaturesDescription { get; set; } = null!;
}
