using BlazorProject.Models.Generic;

namespace BlazorProject.Models.Home;

public class WorkToolsModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<FeatureBoxModel>? WorkToolBox { get; set; }
}
