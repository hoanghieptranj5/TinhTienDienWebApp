using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TinhTienDienWebApp.Helpers;
using TinhTienDienWebApp.Logics;
using TinhTienDienWebApp.Models;

namespace TinhTienDienWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Calculator _calculator;
        private readonly CurrencyFormatter _formatter;

        public HomeController(ILogger<HomeController> logger, Calculator calculator, CurrencyFormatter formatter)
        {
            _logger = logger;
            _calculator = calculator;
            _formatter = formatter;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int usage)
        {
            var result = _calculator.Calculate(usage);
            ViewData["CalculateModel"] = _formatter.FormatModel(result);
            var abc = _formatter.FormatModel(result);
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