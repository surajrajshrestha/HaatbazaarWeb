using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public partial class UserOtp
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Otp { get; set; } = null!;

    public DateTime DateSent { get; set; }

    public bool Used { get; set; }

    public bool Expired { get; set; }
}
