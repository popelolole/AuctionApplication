using System.Media;
using AuctionApplication.Core;
using AuctionApplication.Core.Interfaces;
using AuctionApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.Controllers
{
    [Authorize]
    public class AuctionsController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: AuctionsController
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAllActive(User.Identity.Name);
            List<AuctionVM> auctionVMs = new();
            foreach(var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        
        // GET: AuctionsController/Details/5
        public ActionResult Details(int id)
        {
            Auction auction = _auctionService.GetById(id);
            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return View(detailsVM);
        }

        // GET: AuctionsController/Created
        public ActionResult Created()
        {
            string userName = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetAllByUserName(userName);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/MyBids
        public ActionResult MyBids()
        {
            string userName = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetAllActiveByBidUserName(userName);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/Won
        public ActionResult Won()
        {
            string userName = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetAllWonByUserName(userName);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/ByUser?username=user
        [Authorize(Roles = "Admin")]
        public ActionResult ByUser(string userName)
        {
            List<Auction> auctions = _auctionService.GetAllByUserName(userName);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View((userName, (IEnumerable<AuctionVM>) auctionVMs));
        }

        // GET: AuctionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVM vm)
        {
            string userName = User.Identity.Name;
            if(ModelState.IsValid)
            {
                Auction auction = new Auction(vm.Name,
                                              userName,
                                              (vm.Description!=null?vm.Description:"-"),
                                              vm.StartingPrice,
                                              vm.ClosingTime);
                _auctionService.Add(auction);
                return RedirectToAction("Created");
            }
            return View(vm);
        }

        // GET: AuctionsController/Edit/5
        public ActionResult Edit(int id)
        {
            Auction auction = _auctionService.GetById(id);
            if (!auction.UserName.Equals(User.Identity.Name)) return BadRequest();
            AuctionVM auctionVM = AuctionVM.FromAuction(auction);
            return View();
        }

        // POST: AuctionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditAuctionVM vm)
        {
            Auction auction = _auctionService.GetById(id);
            if(!auction.UserName.Equals(User.Identity.Name)) return BadRequest();

            if (ModelState.IsValid)
            {
                _auctionService.Edit(id, vm.Description);
                return RedirectToAction("Created");
            }
          
            return View(vm);
        }

        // GET: AuctionsController/Bid/5
        public ActionResult Bid(int id)
        {
            Auction auction = _auctionService.GetById(id);
            if (auction.UserName.Equals(User.Identity.Name) || auction.ClosingTime < DateTime.Now) return BadRequest();
            return View();
        }

        // POST: AuctionsController/Bid/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bid(int id, PlaceBidVM vm)
        {
            Auction auction = _auctionService.GetById(id);
            if (auction.UserName.Equals(User.Identity.Name)) return BadRequest();

            if (ModelState.IsValid)
            {
                Bid bid = new Bid(User.Identity.Name, vm.Price, id);
                ValidationResult result = _auctionService.Place(bid);
                if(result.IsSuccess)
                    return RedirectToAction("Details", new { id });
                ModelState.AddModelError("Price", result.ErrorMessage);
                return View(vm);
            }
            return View(vm);
        }

        // GET: AuctionsController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Auction auction = _auctionService.GetById(id);
            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return View(detailsVM);
        }

        // POST: AuctionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, IFormCollection fc)
        {
            _auctionService.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
