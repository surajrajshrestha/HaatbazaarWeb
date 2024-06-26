namespace HaatBazaar.Web.Models.Connections
{
    public class ConnectionResponseModel
    {
        public BuyerDetailModel Buyer { get; set; } = new(); 
        public ItemDetailModel Item { get; set; } = new();
        public SellerDetailModel Seller { get; set; } = new();
    }
}
