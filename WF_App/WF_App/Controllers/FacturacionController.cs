using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WF_App.Models;

namespace WF_App.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly ILogger<FacturacionController> _logger;

        public FacturacionController(ILogger<FacturacionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
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
