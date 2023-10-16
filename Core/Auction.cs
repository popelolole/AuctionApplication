namespace AuctionApplication.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public int StartingPrice { get; set; }
        public DateTime ClosingTime { get; set; }
        private List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;

        public Auction(int id, string name, string userName, int startingPrice, DateTime closingTime) 
        {
            Id = id;
            Name = name;
            UserName = userName;
            StartingPrice = startingPrice;
            ClosingTime = closingTime;
        }

        public Auction(int id, string name, string description, string userName, int startingPrice, DateTime closingTime)
        {
            Id = id;
            Name = name;
            Description = description;
            UserName = userName;
            StartingPrice = startingPrice;
            ClosingTime = closingTime;
        }

        public void AddBid(Bid newBid)
        {
            _bids.Add(newBid);
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - {ClosingTime}";
        }
    }
}
