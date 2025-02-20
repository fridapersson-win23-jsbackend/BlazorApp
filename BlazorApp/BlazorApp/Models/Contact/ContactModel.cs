﻿using System.ComponentModel.DataAnnotations;

namespace BlazorWebbApp.Models.Contact;

public class ContactModel
{
    [Required(ErrorMessage = "Name must be at least 2 characters")]
    [Display(Name = "Full name", Prompt = "Enter your full name")]
    [DataType(DataType.Text)]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "You have to enter a name")]
    public string Name { get; set; } = null!;



    [Required(ErrorMessage = "You have to enter a valid email")]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Invalid email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "Message must be atleast 5 characters")]
    [Display(Name = "Message", Prompt = "Enter your message here...")]
    [DataType(DataType.MultilineText)]
    [StringLength(1000, MinimumLength = 5)]
    public string Message { get; set; } = null!;



    public string[] Services { get; set; } = new string[]
    {
        "Software Development",
        "AI & Data Analytics",
        "IT Consulting",
        "Cyber Security",
        "Cloud Solutions",
        "Customer Service",
        "Career",
        "Connect"
    };


    [Display(Name = "Services", Prompt = "Choose the service you are interested in")]
    [DataType(DataType.Text)]
    public string? SelectedService { get; set; }
}
