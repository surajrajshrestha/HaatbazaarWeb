namespace HaatBazaar.Web.Models.UserItems;

public sealed class UserItemDisplayModel
{
    public int Id { get; set; } = 6;
    public string? Item { get; set; }

    public float Quantity { get; set; }

    public string? Unit { get; set; }

    public decimal Price { get; set; }
}
