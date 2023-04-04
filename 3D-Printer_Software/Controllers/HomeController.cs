using _3D_Printer_Software.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

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
        [HttpGet]
        public IActionResult CirclePage()
        {
            var model = new CircleShape();
            return View(model);
        }

        [HttpPost]
        public IActionResult CirclePage(CircleShape model)
        {
            // Calculate perimeter of circle using user input
            if (ModelState.IsValid)
            {
                double radius = model.Radius.GetValueOrDefault();
                double centerX = model.CenterX.GetValueOrDefault();
                double centerY = model.CenterY.GetValueOrDefault();

                double perimeter = 2 * Math.PI * radius;

                model.Perimeter = perimeter;
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult RectanglePage()
        {
            var model = new RectangleShape();
            return View(model);
        }

        [HttpPost]
        public IActionResult RectanglePage(RectangleShape model)
        {
            // Calculate perimeter of the rectangle
            var perimeter = 2 * (model.Length + model.Width);

            // Add perimeter to model
            model.Perimeter = perimeter;

            return View("RectanglePage", model);
        }

        [HttpGet]
        public IActionResult TrianglePage()
        {
            var model = new TriangleShape();
            return View(model);
        }

        [HttpPost]
        public IActionResult TrianglePage(TriangleShape triangle)
        {
            if (ModelState.IsValid)
            {
                if (triangle.Side1.HasValue && triangle.Side2.HasValue && triangle.Side3.HasValue)
                {
                    // Calculate the perimeter of the triangle
                    int perimeter = triangle.Side1.Value + triangle.Side2.Value + triangle.Side3.Value;
                    triangle.Perimeter = perimeter;
                }
                return View(triangle);
            }
            else
            {
                return View();
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