namespace HaatBazaar.Web.Models.Connections
{
    public class ConnectionResponseModel
    {
        public bool IsSeller { get; set; }
        public int ConnectionId { get; set; }
        public int LoggedInUser { get; set; }
        public string ContractStatus { get; set; } = "";
        public BuyerDetailModel Buyer { get; set; } = new();
        public ItemDetailModel Item { get; set; } = new();
        public SellerDetailModel Seller { get; set; } = new();
    }
}
