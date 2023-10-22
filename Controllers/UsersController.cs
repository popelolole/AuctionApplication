using AuctionApplication.Core;
using AuctionApplication.Core.Interfaces;
using AuctionApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            List<User> users = _userService.GetAll();
            List<UserVM> userVMs = new();

            foreach(var user in  users)
            {
                userVMs.Add(UserVM.FromUser(user));
            }
            return View(userVMs);
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(string id)
        {
            User user = _userService.GetById(id);
            UserVM userVM = UserVM.FromUser(user);
            return View(userVM);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
