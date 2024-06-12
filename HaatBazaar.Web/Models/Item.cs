namespace HaatBazaar.Web.Models;

public class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Tags { get; set; } = null!;

    public Guid RowGuid { get; set; }

    public virtual Category Category { get; set; } = null!;
}
