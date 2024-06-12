using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public partial class RefreshToken
{
    public int Id { get; set; }

    public string? Token { get; set; }

    public string? Jwt { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool? Used { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
