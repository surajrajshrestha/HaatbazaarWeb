namespace HaatBazaar.Web.Models;

public class Register
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; } = null!;
    public required string Password { get; set; } = null!;
    public string? Email { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set;}
}

public class Login
{

    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
}
