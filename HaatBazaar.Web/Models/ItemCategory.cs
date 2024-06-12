namespace HaatBazaar.Web.Models;

public  class ItemCategory
{
    public int CategoryId { get; set; }

    public int ItemId { get; set; }

    public Guid? RowGuid { get; set; }

    public virtual Category Category { get; set; } = null!;
}
