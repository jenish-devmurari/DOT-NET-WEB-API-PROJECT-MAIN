using System.ComponentModel.DataAnnotations;

namespace MyTeam_1DTO
{
    public class UpdatePasswordDTO
    {
   
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password Must contain 8 character and also have at least 1 Digit,1 Alphabet and 1 Special Character")]
        public string Current_Password { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password Must contain 8 character and also have at least 1 Digit,1 Alphabet and 1 Special Character")]
        public string New_Password { get; set; }
    }
}
