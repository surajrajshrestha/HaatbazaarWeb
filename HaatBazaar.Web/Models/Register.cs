namespace HaatBazaar.Web.Models;

public class Register
{
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Phone Number is required.")]
    [Phone(ErrorMessage = "Invalid Phone Number format.")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string? Email { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
}

public class Login
{
    [Required(ErrorMessage = "Phone Number is required.")]
    [Phone(ErrorMessage = "Invalid Phone Number format.")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = null!;
}

