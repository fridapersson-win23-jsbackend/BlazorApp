namespace BlazorProject.Models.Home
{
    public class ShowcaseModel
    {
        public string? Id { get; set; }
        public ImageModel? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public LinkModel? Link { get; set; }
        public string? BrandsText { get; set; }
        public List<ImageModel>? BrandImages { get; set; }
    }
}
