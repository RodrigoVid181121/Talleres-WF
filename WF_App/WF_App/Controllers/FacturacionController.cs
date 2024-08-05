using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.Json;
using WF_App.Models;
using WF_App.Models.Stored_Procedures;
using WF_App.Models.ViewModels;

namespace WF_App.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly ILogger<FacturacionController> _logger;
        private readonly DbTalleresContext _context;
        private readonly FacturacionSP _fact;

        public FacturacionController(ILogger<FacturacionController> logger, DbTalleresContext context, FacturacionSP fact)
        {
            _logger = logger;
            _context = context;
            _fact = fact;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewData["Productos"] = new SelectList(_context.Productos, "Id", "Codigo");
            return View();
        }

        #region Metodos de Desencriptado de la informacion
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
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }

        }
        private class Productos()
        {
            public string Id { get; set; }
            public string Producto { get; set; }
        }

        private class Servicios()
        {
            public string servicio { get; set; }
        }
        #endregion

        static Productos[] EliminarDuplicados(Productos[] productosArray)
        {
            List<Productos> productosUnicos = new List<Productos>();
            HashSet<string> idsUnicos = new HashSet<string>();

            foreach (var producto in productosArray)
            {
                // Usamos Id como identificador único
                if (!idsUnicos.Contains(producto.Id))
                {
                    productosUnicos.Add(producto);
                    idsUnicos.Add(producto.Id);
                }
            }

            return productosUnicos.ToArray();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Fact(FacturacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.TipoDoc = "Ticket";
                #region Desencriptado de Servicios
                var keyService = model.Descripcion.Substring(0, 32);
                var ivService = model.Descripcion.Substring(33, 24);
                var jsonService = model.Descripcion.Substring(58, model.Descripcion.Length - 58);
                var ser = Decrypt(jsonService, keyService, ivService);
                Servicios[] servicios = JsonSerializer.Deserialize<Servicios[]>(ser);
                model.Descripcion = "Los servicios brindados son: ";
                for(int i = 0; i<servicios.Length; i++)
                {
                    if(i == servicios.Length -1)
                        model.Descripcion += servicios[i].servicio.ToString();
                    else
                        model.Descripcion += servicios[i].servicio.ToString() + ", ";

                }
                await _fact.SP_CreateFactura(model);
                #endregion
                #region Desencriptado de Productos y Creación de Detalle de la Venta
                var keyProducts = model.Productos.Substring(0, 32);
                var ivProducts = model.Productos.Substring(33,24);
                var jsonProducts = model.Productos.Substring(58,model.Productos.Length-58);

                var products = Decrypt(jsonProducts, keyProducts, ivProducts);
                Productos[] prod = JsonSerializer.Deserialize<Productos[]>(products);
                Productos[] limpio = EliminarDuplicados(prod);

                for(int i = 0; i < limpio.Length; i++)
                {
                    model.Cantidad = prod.Count(x => x.Id == limpio[i].Id);
                    model.IdProductos = Convert.ToInt32(limpio[i].Id);

                   await _fact.CreateDetailFactura(model);
                }
                #endregion
                
            }
            return RedirectToAction(nameof(Create));
        }
        [HttpPost]
        public JsonResult SearchPlaca(string placa)
        {
            var costos = _context.Productos.Select(
                p => new
                {
                    ID = p.Id,
                    Costo = p.PrecioVenta                    
                }
                ).ToList();
            var infoVehiculo = _context.Vehiculos.Where(v => v.Placa == placa).FirstOrDefault();
            if (infoVehiculo != null)
            {
                var info = from s in _context.Servicios
                           join ls in _context.ListaServicios on s.IdServicio equals ls.Id
                           join cl in _context.Clientes on infoVehiculo.IdCliente equals cl.Id
                           where s.Estado == true && s.Anulado == false
                           select new
                           {
                               ID = ls.Id,
                               Servicio = ls.Nombre,
                               Encargado = s.EncargadoVehi,
                               Nombre = cl.Nombre
                           };
                var envío = new
                {
                    ArrayInfo = info,
                    ArrayCostos = costos
                };
                return Json(envío);
            }
            else
            {               
               return Json(costos);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
