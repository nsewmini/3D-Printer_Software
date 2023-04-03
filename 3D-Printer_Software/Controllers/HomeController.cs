using _3D_Printer_Software.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3D_Printer_Software.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new dropdownlist();
            return View(model);
        }
        [HttpPost]
        public IActionResult ShapeSelection(int ID)
        {
            // Based on the shapeId parameter, determine which page to redirect to
            switch (ID)
            {
                case 1: // circle
                    return RedirectToAction("CirclePage");
                case 2: // rectangle
                    return RedirectToAction("RectanglePage");
                case 3: // triangle
                    return RedirectToAction("TrianglePage");
                default:
                    return RedirectToAction("Index");
            }
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