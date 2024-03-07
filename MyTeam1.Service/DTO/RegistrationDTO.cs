
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyTeam_1.DTO
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        public int? TotalMatchesPlayed { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [JsonIgnore]

        public string Password { get; set; } = "Team@1234";

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime DateOfBirth { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }
    }
}
