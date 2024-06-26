namespace HaatBazaar.Web.Models.Connections
{
    public class SellerDetailModel
    {
        public int SellerId { get; set; }
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string? Address { get; set; } = "";
        public decimal Rating { get; set; }

        public List<ItemDetailModel> Items { get; set; } = new List<ItemDetailModel>();
    }
}
