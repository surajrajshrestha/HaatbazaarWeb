using System;
using System.Collections.Generic;

namespace HaatBazaar.Web.Models;

public partial class ItemImage
{
    public int ItemId { get; set; }

    public int ImageId { get; set; }

    public Guid? RowGuid { get; set; }

    public virtual Image Image { get; set; } = null!;
}
