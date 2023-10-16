namespace AuctionApplication.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public Bid(int id, string userName, int price)
        {
            Id = id;
            UserName = userName;
            Price = price;
            CreatedDate = DateTime.Now;
        }
    }
}
