using BetService.Repository.Interfaces;
using System.Web.Mvc;

namespace BetService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayersService playersService;
        public HomeController(IPlayersService playersService)
        {
            this.playersService = playersService;
        }
        public ActionResult Index()
        {
            var model = this.playersService.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}