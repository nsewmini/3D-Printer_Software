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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //circle perimeter calculation
        [HttpGet]
        public IActionResult CirclePage()
        {
            var model = new CircleShape();
            return View(model);
        }

        [HttpPost]
        public IActionResult CirclePage(CircleShape model)
        {
            if (ModelState.IsValid)
            {
                double radius = model.Radius.GetValueOrDefault();
                double centerX = model.CenterX.GetValueOrDefault();
                double centerY = model.CenterY.GetValueOrDefault();

                double perimeter = 2 * Math.PI * radius;
                double liqued = 1.5 * perimeter;

                model.Perimeter = perimeter;
                model.Liqued = liqued;
            }

            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //rectangle perimeter implemetation

        [HttpGet]
        public IActionResult RectanglePage()
        {
            var model = new RectangleShape();
            return View(model);
        }

        [HttpPost]
        public IActionResult RectanglePage(RectangleShape model)
        {
            if (ModelState.IsValid)
            {
                double length = model.Length.GetValueOrDefault();
                double width = model.Width.GetValueOrDefault();

                double perimeter = 2 * (length + width);
                double liqued = 1.5 * perimeter;

                

                model.Perimeter = perimeter;
                model.Liqued = liqued;
            }
            else
            {

                ModelState.AddModelError(string.Empty, "The entered side lengths cannot form a valid rectangle.");
            }

            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //triangle perimeter implementation
        [HttpGet]
        public IActionResult TrianglePage()
        {
            var model = new TriangleShape();
            return View(model);
        }

        [HttpPost]
        public IActionResult TrianglePage(TriangleShape model)
        {
            if (ModelState.IsValid)
            {
                int side1 = model.Side1.GetValueOrDefault();
                int side2 = model.Side2.GetValueOrDefault();
                int side3 = model.Side3.GetValueOrDefault();

                if (side1 + side2 > side3 && side2 + side3 > side1 && side1 + side3 > side2)
                {
                    int perimeter = side1 + side2 + side3;

                    model.Perimeter = perimeter;
                    double liqued = 1.5 * perimeter;
                    model.Liqued = liqued;
                }
                else
                {
                    
                    ModelState.AddModelError(string.Empty, "The entered side lengths cannot form a valid triangle.");
                }
            }

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
     
      
    }
}