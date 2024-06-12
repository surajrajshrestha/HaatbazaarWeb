using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public partial class UserItem
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ItemId { get; set; }

    public float Quantity { get; set; }

    public string Unit { get; set; } = null!;

    public decimal Price { get; set; }

    public string PriceUnit { get; set; } = null!;

    public bool Sold { get; set; }

    public virtual User User { get; set; } = null!;
}
