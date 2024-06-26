namespace HaatBazaar.Web.Models.Connections
{
    public class ItemDetailModel
    {
        public string ItemName { get; set; } = "";
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public string Unit { get; set; } = "";
    }
}
