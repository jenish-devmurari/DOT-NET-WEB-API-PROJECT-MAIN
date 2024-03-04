using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTeam_1.DTO
{
    public class LoginDTO
    {
    
        [Key]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*\W).{8,}$", ErrorMessage ="Password Must contain 8 character and also have at least 1 Digit,1 Alphabet and 1 Special Character")]
        public string Password { get; set; }
    }
}
