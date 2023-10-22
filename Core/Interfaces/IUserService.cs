using AuctionApplication.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Core.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(string id);
        void Delete(string id);
    }
}
