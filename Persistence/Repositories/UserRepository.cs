using AuctionApplication.Areas.Identity.Data;
using AuctionApplication.Data;
using AuctionApplication.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence.Repositories
{
    public class UserRepository : Repository<AuctionApplicationUser>, IUserRepository
    {
        public UserRepository(AuctionApplicationIdentityContext context) : base(context)
        {
        }

        public AuctionApplicationUser Get(string id)
        {
            return DbContext.Users.Find(id);
        }

        public AuctionApplicationIdentityContext DbContext
        {
            get { return Context as AuctionApplicationIdentityContext; }
        }
    }
}
