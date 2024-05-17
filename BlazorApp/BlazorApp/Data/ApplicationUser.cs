using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;

        [Required]
        [ProtectedPersonalData]
        public string LastName { get; set; } = null!;
        public string? ProfilePicture { get; set; } = "/uploads/no-profile-img.png";
        public string? Biography { get; set; }

        public int? AddressId { get; set; }
        public AddressEntity? Address { get; set; }
        
    }

    public class AddressEntity
    {
        public int Id { get; set; }
        public string AddressLine_1 { get; set; } = null!;
        public string? AddressLine_2 { get; set; }
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
