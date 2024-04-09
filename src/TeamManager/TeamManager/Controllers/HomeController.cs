using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeamManager.Models;
using TeamManager.Repository.Common;

namespace TeamManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IRepository<Project, Guid> repository;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //this.repository = repository;
        }

        public IActionResult Index()
        {
            //return View(repository.GetAllAsync());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
