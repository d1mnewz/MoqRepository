using Microsoft.AspNetCore.Mvc;
using MoqRepositorySample.Data.Repository;

namespace Web.Controllers
{
    public class HomeController<T> : Controller
    {
        protected IRepository<T> Repository;

        public HomeController(IRepository<T> rep)
        {
            this.Repository = rep;
        }

        public IActionResult Index()
        {

            return View(this.Repository.FindAll());
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
