namespace HaatBazaar.Web.Models.Blocks
{
    public sealed class Block
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Data { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public int Nonce { get; set; }
    }
}
