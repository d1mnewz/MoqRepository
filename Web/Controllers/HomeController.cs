using Microsoft.AspNetCore.Mvc;
using MoqRepositoryCore.Data;

namespace Web.Controllers
{
    public class HomeController<T> : Controller
    {
        IRepository<T> _repository;

        public HomeController(IRepository<T> rep)
        {
            this._repository = rep;
        }

        public IActionResult Index()
        {

            return View(this._repository.FindAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
