using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Account;

public class AccountDetailsModel
{
    [Required(ErrorMessage = "Invalid first name")]
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "Invalid last name")]
    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;


    [Required(ErrorMessage = "Invalid email")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email address")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;


    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone number", Prompt = "Enter your phone number")]
    public string? PhoneNumber { get; set; }


    [DataType(DataType.MultilineText)]
    [Display(Name = "Bio", Prompt = "Add a short bio...")]
    public string? Biography { get; set; }

    public bool IsExternalAccount { get; set; }


    [Required(ErrorMessage = "Invalid Address")]
    [Display(Name = "Address line 1", Prompt = "Enter a addressline")]
    [DataType(DataType.Text)]
    public string AddressLine_1 { get; set; } = null!;


    [Display(Name = "Address line 2", Prompt = "Enter your second addressline")]
    [DataType(DataType.Text)]
    public string? AddressLine_2 { get; set; }


    [Required(ErrorMessage = "Invalid postal code")]
    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;


    [Required(ErrorMessage = "Invalid city")]
    [Display(Name = "City", Prompt = "Enter a city")]
    [DataType(DataType.Text)]
    public string City { get; set; } = null!;
}
