using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using WF_App.Models;
using WF_App.Models.ViewModels;

namespace WF_App.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly ILogger<ServiciosController> _logger;
        private readonly DbTalleresContext _context;

        public ServiciosController(ILogger<ServiciosController> logger, DbTalleresContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var info = _context.IndexSelect();
            return View(info);
        }
        public IActionResult Create()
        {
            ViewData["Gas"] = new SelectList(_context.Gas, "Id", "Nombre");
            var id = 0;
            id = Convert.ToInt32(Request.Form["serviceId"]);
            if (id != 0)
            {
                var service = _context.SP_SelectAllService(id);
                return View(service);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActionMethod(ServiciosViewModel model)
        {
            if (ModelState.IsValid)
            {
                switch (model.Action)
                {
                    case "Create":
                        await CreateService(model);
                        return RedirectToAction(nameof(Index));

                    case "Finalizar":
                        await Final(model);
                        return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Gas"] = new SelectList(_context.Gas, "Id", "Nombre", model.Combustible);
            return View("Create", model);
        }
        private async Task CreateService(ServiciosViewModel model)
        {
            if (model.Celular.Length == 8)
            {
                string sub = model.Celular.Substring(0, 4);
                string sub2 = model.Celular.Substring(4, 4);
                model.Celular = sub + "-" + sub2;
            }
            await _context.InsertClientSP(model);
            await _context.VehiculoSP(model);
            switch (model.Distancia)
            {
                //commit for nothing
                case "Kilometros":
                    if (model.Encargado == null) model.Encargado = "";
                    if (model.Cargo == null) model.Cargo = "";
                    if (model.Comentarios == null) model.Comentarios = "";
                    if (model.Imagen == null) model.Imagen = "";
                    await _context.ServiciosSP(model);
                    break;
                case "Millas":
                    if (model.Encargado == null) model.Encargado = "";
                    if (model.Cargo == null) model.Cargo = "";
                    if (model.Comentarios == null) model.Comentarios = "";
                    if (model.Imagen == null) model.Imagen = "";
                    await _context.ServiciosSP(model);
                    break;
            }
        }

        private async Task Final(ServiciosViewModel model)
        {
            if (model.Encargado == null) model.Encargado = "";
            if (model.Cargo == null) model.Cargo = "";
            if (model.Comentarios == null) model.Comentarios = "";
            if (model.Imagen == null) model.Imagen = "";

            await _context.SP_FinalService(model, Convert.ToInt32(model.KilOut));
        }
        [HttpPost]
        public IActionResult SearchPlaca(ServiciosViewModel placa)
        {
            if (!String.IsNullOrEmpty(placa.PlacaSearch))
            {
                var model = _context.SP_FillInfo(placa.PlacaSearch);
                ViewData["Gas"] = new SelectList(_context.Gas, "Id", "Nombre");

                return View("Create",model);
            }
            else
            {                
                return View("Create");
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
