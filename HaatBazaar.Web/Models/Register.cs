using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public class Register
{

    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
}

public class Login
{

    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
}
