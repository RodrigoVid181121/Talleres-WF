using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.Json;
using WF_App.Models;
using WF_App.Models.ViewModels;
using System.Text.Json;
using WF_App.Models.Stored_Procedures;

namespace WF_App.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly ILogger<ServiciosController> _logger;
        private readonly DbTalleresContext _context;
        private readonly Servicios _spServices;

        public ServiciosController(ILogger<ServiciosController> logger, DbTalleresContext context, Servicios sp)
        {
            _logger = logger;
            _context = context;
            _spServices = sp;
        }

        public IActionResult Index()
        {
            var info = _spServices.IndexSelect();
            return View(info);
        }
        public IActionResult Create()
        {
            ViewData["Gas"] = new SelectList(_context.Gas, "Id", "Nombre");
            ViewData["Services"] = new SelectList(_context.ListaServicios, "Id", "Nombre");
            var id = 0;
            id = Convert.ToInt32(Request.Form["serviceId"]);
            if (id != 0)
            {
                var service = _spServices.SP_SelectAllService(id);
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
        private static byte[] HexStringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private string Decrypt(string encrypt, string key, string iv)
        {
            byte[] keyBytes = HexStringToByteArray(key);

            // Convertir IV de base64 a bytes
            byte[] ivBytes = Convert.FromBase64String(iv);

            // Convertir el texto encriptado de base64 a bytes
            byte[] encryptedBytes = Convert.FromBase64String(encrypt);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms,decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
            
        }
        private class Service()
        {
            public string Id { get; set; }
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
            
            await _spServices.InsertClientSP(model);
            await _spServices.VehiculoSP(model);

            var index = model.key.Length - 58;
            var key = model.key.Substring(0, 32);
            var iv = model.key.Substring(33, 24);
            var json = model.key.Substring(58, index);

            var dec = Decrypt(json, key, iv);
            Service[] ser = JsonSerializer.Deserialize<Service[]>(dec);
            switch (model.Distancia)
            {
                //commit for nothing
                case "Kilometros":
                    if (model.Encargado == null) model.Encargado = "";
                    if (model.Cargo == null) model.Cargo = "";
                    if (model.Comentarios == null) model.Comentarios = "";
                    if (model.Imagen == null) model.Imagen = "";
                    for(int i = 0; i < ser.Length; i++)
                    {
                        model.IdServicio = Convert.ToInt32(ser[i].Id.ToString());
                        await _spServices.ServiciosSP(model);
                    }                    
                    break;
                case "Millas":
                    if (model.Encargado == null) model.Encargado = "";
                    if (model.Cargo == null) model.Cargo = "";
                    if (model.Comentarios == null) model.Comentarios = "";
                    if (model.Imagen == null) model.Imagen = "";
                    for (int i = 0; i < ser.Length; i++)
                    {
                        model.IdServicio = Convert.ToInt32(ser[i].ToString());
                        await _spServices.ServiciosSP(model);
                    }
                    break;
            }
        }

        private async Task Final(ServiciosViewModel model)
        {
            if (model.Encargado == null) model.Encargado = "";
            if (model.Cargo == null) model.Cargo = "";
            if (model.Comentarios == null) model.Comentarios = "";
            if (model.Imagen == null) model.Imagen = "";

            await _spServices.SP_FinalService(model, Convert.ToInt32(model.KilOut));
        }
        [HttpPost]
        public IActionResult SearchPlaca(ServiciosViewModel placa)
        {
            if (!String.IsNullOrEmpty(placa.PlacaSearch))
            {
                var model = _spServices.SP_FillInfo(placa.PlacaSearch);
                ViewData["Gas"] = new SelectList(_context.Gas, "Id", "Nombre");
                ViewData["Services"] = new SelectList(_context.ListaServicios, "Id", "Nombre");
                return View("Create",model);
            }
            else
            {                
                return View("Create");
            }
            
        }

        public string Anulation(int id)
        {
            if (id > 0)
            {
                Servicio ser = _context.Servicios.Where(s => s.Id == id).FirstOrDefault();
                ser.Anulado = true;

                _context.SaveChanges();
                return "Anulada";
            }
            else
            {
                return "No anulada";
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
