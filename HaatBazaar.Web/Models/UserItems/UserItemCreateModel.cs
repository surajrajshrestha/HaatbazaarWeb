namespace HaatBazaar.Web.Models.UserItems
{
    public class UserItemCreateModel
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public float Quantity { get; set; }
        public string? Unit { get; set; }
        public decimal Price { get; set; }

        public List<BaseItemModel>? Items { get; set; }
    }

    public class BaseItemModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
