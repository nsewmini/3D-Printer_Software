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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //add the shapes for the dropdown list
        private List<ShapesVM> GetShapes()
        {

            var companies = new List<ShapesVM>();
            companies.Add(new ShapesVM()
            {
                ID = 1,
                shapetype = "circle"
            });
            companies.Add(new ShapesVM()
            {
                ID = 2,
                shapetype = "rectangle"
            }); companies.Add(new ShapesVM()
            {
                ID = 3,
                shapetype = "triangle"
            });
            return companies;
        }



    }
}