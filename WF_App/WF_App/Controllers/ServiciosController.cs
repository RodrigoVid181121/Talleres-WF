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
                        break;

                    case "Finalizar":
                       await Final(model);
                        break;
                }
            }
            // ViewData["Gas"] = new SelectList(_context.Gas, "Id", "Nombre", model.Combustible);
            return RedirectToAction(nameof(Index));
        }
        public async Task <IActionResult> CreateService(ServiciosViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Celular.Length == 8)
                {
                    string sub = model.Celular.Substring(0,4);
                    string sub2 = model.Celular.Substring(4, 4);
                    model.Celular = sub + "-" + sub2;
                }
                await _context.InsertClientSP(model);
                await _context.VehiculoSP(model.Llaves,model.Tarjeta,model.Poliza,model.Control_Alarma,
                    model.Placa,model.Marca,model.Modelo,model.Color,model.Año,model.Tipo,model.Combustible,
                    model.Celular,model.Radio,model.MascRad,model.PerillaCal,model.AC,model.ControlAlarma,model.Pito,
                    model.EspejoIn,model.EspejoExt,model.Antena,model.TapaLlanta,model.EmbLat,model.EmbPost,model.Gato,
                    model.LlaveRuedas,model.Herramientas,model.KitCarretera,model.TapaGas,model.Encendedor,model.TapaLiqFrenos,
                    model.TapaFusibles,model.Alfombras,model.LlantaEmergencia,model.CopaLlanta,model.CableCorriente);
                switch (model.Distancia)
                {
                    //commit for nothing
                    case "Kilometros":
                        if (model.Encargado == null) model.Encargado = "";
                        if (model.Cargo == null) model.Cargo = "";
                        if (model.Comentarios == null) model.Comentarios = "";
                        if (model.Imagen == null) model.Imagen = "";
                        await _context.ServiciosSP(model.CantGas, model.KilIn, model.Distancia, model.Imagen, model.Receptor, model.Mecanico,
                            model.Encargado, model.Cargo, model.Comentarios,model.Placa);
                        break;
                    case "Millas":
                        break;
                }

            }
            ViewData["Gas"] = new SelectList(_context.Gas, "Id", "Nombre",model.Combustible);
            return View(model);
        }

        public async Task<IActionResult> Final(ServiciosViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Encargado == null) model.Encargado = "";
                if (model.Cargo == null) model.Cargo = "";
                if (model.Comentarios == null) model.Comentarios = "";
                if (model.Imagen == null) model.Imagen = "";

                await _context.SP_FinalService(model.Llaves, model.Tarjeta, model.Poliza, model.Control_Alarma,
                    model.Placa, model.Marca, model.Modelo, model.Color, model.Año, model.Tipo, model.Combustible,
                    model.Celular, model.Radio, model.MascRad, model.PerillaCal, model.AC, model.ControlAlarma, model.Pito,
                    model.EspejoIn, model.EspejoExt, model.Antena, model.TapaLlanta, model.EmbLat, model.EmbPost, model.Gato,
                    model.LlaveRuedas, model.Herramientas, model.KitCarretera, model.TapaGas, model.Encendedor, model.TapaLiqFrenos,
                    model.TapaFusibles, model.Alfombras, model.LlantaEmergencia, model.CopaLlanta, model.CableCorriente,
                    Convert.ToInt32(model.KilOut));
            }
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
