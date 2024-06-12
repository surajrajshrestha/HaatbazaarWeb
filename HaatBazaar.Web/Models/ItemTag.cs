using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public partial class ItemTag
{
    public long Id { get; set; }

    public int ItemId { get; set; }

    public long TagId { get; set; }

    public virtual Tag Tag { get; set; } = null!;
}
