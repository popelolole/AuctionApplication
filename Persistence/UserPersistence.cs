using AuctionApplication.Areas.Identity.Data;
using AuctionApplication.Core;
using AuctionApplication.Core.Interfaces;
using AuctionApplication.Data;
using AuctionApplication.Persistence.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence
{
    public class UserPersistence : IUserPersistence
    {
        private IUserUnitOfWork _unitOfWork;

        public UserPersistence(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<User> GetAll()
        {
            var userDBs = _unitOfWork.Users.GetAll();

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
            AuctionApplicationUser userDB = _unitOfWork.Users.Get(id);
            return new User(userDB.Id, userDB.UserName, userDB.Email, userDB.PhoneNumber);
        }

        public void Delete(string id)
        {
            AuctionApplicationUser userDB = _unitOfWork.Users.Get(id);
            if (userDB != null) {
                _unitOfWork.Users.Remove(userDB);
                _unitOfWork.Commit();
            }
        }
    }
}
