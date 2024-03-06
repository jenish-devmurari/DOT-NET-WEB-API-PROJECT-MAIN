using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class User
{

  
    [Key]
    public int UserID { get; set; }

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

    [Required(ErrorMessage = "Password is Required")]

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password Must contain 8 character and also have at least 1 Digit,1 Alphabet and 1 Special Character")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]

    public DateTime DateOfBirth { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    [DefaultValue(0)]
    public int RoleID { get; set; }

   
    [DefaultValue(false)]
    public bool IsPlaying { get; set; }

  

}



