using BetService.Models;
using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using System.Web.Mvc;

namespace BetService.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventsService eventsService;

        public EventController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }
        // GET: Event
        public ActionResult Index()
        {
            var model = this.eventsService.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = this.eventsService.GetById(id);
            if (model == null)
                //return RedirectToAction("Index");
                return View("NotFound");
            return View(model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Events events)
        {
            if (events.KickOff == null)
            {
                ModelState.AddModelError(nameof(events.KickOff), "KickOff should be enter...");
            }
            if (events.Result == null)
            {
                ModelState.AddModelError(nameof(events.Result), "Result should be enter...");
            }
            if (ModelState.IsValid)
            {
                this.eventsService.Insert(events);
                TempData["Message"] = "Operation Successfull";
                return RedirectToAction("Details", new { id = events.EventId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = this.eventsService.GetById(id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Events events)
        {
            if (ModelState.IsValid)
            {
                this.eventsService.Update(events);
                TempData["Message"] = "Operation Successfull";
                return RedirectToAction("Details", new { id = events.EventId });
            }
            return View(events);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = this.eventsService.GetById(id);
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
                this.eventsService.Delete(id);
                TempData["Message"] = "Operation Successfull";
                return RedirectToAction("Index");
            }
            return View("NotFound");
        }
    }
}