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
            List<Auction> auctions = _auctionService.GetAllActive();
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

        // JUST FOR TESTING
        // GET: AuctionsController/All
        public ActionResult All()
        {
            List<Auction> auctions = _auctionService.GetAll();
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
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
                _auctionService.Place(bid);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        /*
        // GET: AuctionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
