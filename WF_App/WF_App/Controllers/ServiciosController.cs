using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public async Task <IActionResult> Create(ServiciosViewModel model)
        {
            Console.Write(model.ToString());
            if (ModelState.IsValid)
            {                
                var client = _context.InsertClientSP(model.Nombre, model.Celular);
                var vehiculo = _context.VehiculoSP(model.Llaves,model.Tarjeta,model.Poliza,model.Control_Alarma,
                    model.Placa,model.Marca,model.Modelo,model.Color,model.Año,model.Tipo,model.Combustible,
                    model.Celular,model.Radio,model.MascRad,model.PerillaCal,model.AC,model.ControlAlarma,model.Pito,
                    model.EspejoIn,model.EspejoExt,model.Antena,model.TapaLlanta,model.EmbLat,model.EmbPost,model.Gato,
                    model.LlaveRuedas,model.Herramientas,model.KitCarretera,model.TapaGas,model.Encendedor,model.TapaLiqFrenos,
                    model.TapaFusibles,model.Alfombras,model.LlantaEmergencia,model.CopaLlanta,model.CableCorriente);
                switch (model.Distancia)
                {
                    case "Kilometros":

                        break;
                    case "Millas":
                        break;
                }
                
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
