namespace HaatBazaar.Web.Models.Connections
{
    public class BuyerDetailModel
    {
        public int BuyerId { get; set; }
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string? Address { get; set; }
    }
}
