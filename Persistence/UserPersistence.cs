using AuctionApplication.Areas.Identity.Data;
using AuctionApplication.Core;
using AuctionApplication.Core.Interfaces;
using AuctionApplication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence
{
    public class UserPersistence : IUserPersistence
    {
        private AuctionApplicationIdentityContext _dbContext;

        public UserPersistence(AuctionApplicationIdentityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            List<AuctionApplicationUser> userDBs = _dbContext.Users
                .Where(p => p.UserName != "")
                .OrderBy(p => p.UserName)
                .ToList();

            List<User> users = new List<User>();

            foreach(var userDB in userDBs)
            {
                User user = new User(userDB.Id, userDB.UserName, userDB.Email, userDB.PhoneNumber);
                users.Add(user);
            }

            return users;
        }

        public User GetById(string id)
        {
            AuctionApplicationUser userDB = _dbContext.Users.Find(id);
            return new User(userDB.Id, userDB.UserName, userDB.Email, userDB.PhoneNumber);
        }

        public void Delete(string id)
        {
            AuctionApplicationUser userDB = _dbContext.Users.Find(id);
            if (userDB != null) {
                _dbContext.Users.Remove(userDB);
                _dbContext.SaveChanges();
            }
        }
    }
}
