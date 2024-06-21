using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WF_App.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly ILogger<ProveedoresController> _logger;

        public ProveedoresController(ILogger<ProveedoresController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
