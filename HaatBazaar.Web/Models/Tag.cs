using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public partial class Tag
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ItemTag> ItemTags { get; set; } = new List<ItemTag>();
}
