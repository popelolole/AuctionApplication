namespace AuctionApplication.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuctionId { get; set; }

        public Bid(string userName, int price, int auctionId)
        {
            Id = 0;
            UserName = userName;
            Price = price;
            CreatedDate = DateTime.Now; 
            AuctionId = auctionId;
        }

        public Bid(int id, string userName, int price, int auctionId)
        {
            Id = id;
            UserName = userName;
            Price = price;
            CreatedDate = DateTime.Now;
            AuctionId = auctionId;
        }
    }
}
