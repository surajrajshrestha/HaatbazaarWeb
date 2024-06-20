using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public bool? Verified { get; set; }

    public DateTime? RegisteredDate { get; set; }

    public string? Password { get; set; }
}
