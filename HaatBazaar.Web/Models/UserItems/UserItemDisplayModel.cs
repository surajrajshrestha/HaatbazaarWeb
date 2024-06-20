namespace HaatBazaar.Web.Models.UserItems;

public sealed class UserItemDisplayModel
{
    public string? Item { get; set; }

    public float Quantity { get; set; }

    public string? Unit { get; set; }

    public decimal Price { get; set; }
}
