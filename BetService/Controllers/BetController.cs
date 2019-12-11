using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using System.Web.Mvc;

namespace BetService.Controllers
{
    public class BetController : Controller
    {
        private readonly IBetsService betsService;

        public BetController(IBetsService betsService)
        {
            this.betsService = betsService;
        }
        // GET: Event
        public ActionResult Index()
        {
            var model = this.betsService.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = this.betsService.GetById(id);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bets bets)
        {
            if (bets.EventId == 0)
            {
                ModelState.AddModelError(nameof(bets.EventId), "EventId should be enter...");
            }
            if (ModelState.IsValid)
            {
                this.betsService.Insert(bets);
                TempData["Message"] = "Operation Successfull";
                return RedirectToAction("Details", new { id = bets.BetId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = this.betsService.GetById(id);
            if (model == null)
                return View("NotFound");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bets bets)
        {
            if (ModelState.IsValid)
            {
                this.betsService.Update(bets);
                TempData["Message"] = "Operation Successfull"; 
                return RedirectToAction("Details", new { id = bets.BetId });
            }
            return View(bets);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = this.betsService.GetById(id);
            if (model == null)
                return View("NotFound");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                this.betsService.Delete(id);
                TempData["Message"] = "Operation Successfull";
                return RedirectToAction("Index");
            }
            return View("NotFound");
        }
    }
}