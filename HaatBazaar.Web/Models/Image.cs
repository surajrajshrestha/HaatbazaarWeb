using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public partial class Image
{
    public int Id { get; set; }

    public string? Path { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<ItemImage> ItemImages { get; set; } = new List<ItemImage>();
}
