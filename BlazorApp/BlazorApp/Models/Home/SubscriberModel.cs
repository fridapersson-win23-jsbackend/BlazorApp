//using BlazorProject.Models.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace BlazorProject.Models.Home;

//public class SubscriberModel
//{
//    public string? Id { get; set; }
//    public string? Title { get; set; }
//    public string? Description { get; set; }
//    public LinkModel? AgreeToTerms { get; set; }
//    public LinkModel? Terms {  get; set; }
//    public LinkModel? PrivacyPolicy { get; set; }
//    public ImageModel? Image { get; set; }
//    public CheckboxModel? Checkbox { get; set; }
//    public LinkModel? SubscribeBtn { get; set; }

//    public string? ErrorMessage { get; set; }

//    [Required(ErrorMessage = "You have to enter a valid email")]
//    [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Invalid email address")]
//    [EmailAddress]
//    public string Email { get; set; } = null!;


//    [Display(Name = "Daily Newsletter")]
//    public bool DailyNewsletter { get; set; } = false;


//    [Display(Name = "Event Updates")]
//    public bool EventUpdates { get; set; } = false;


//    [Display(Name = "Advertising Updates")]
//    public bool AdvertisingUpdates { get; set; } = false;


//    [Display(Name = "Startups Weekly")]
//    public bool StartupsWeekly { get; set; } = false;


//    [Display(Name = "Week In Review")]
//    public bool WeekInReview { get; set; } = false;


//    [Display(Name = "Podcasts")]
//    public bool Podcasts { get; set; } = false;
//}
