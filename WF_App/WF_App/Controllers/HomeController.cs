using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WF_App.Models;
using WF_App.Models.ViewModels;

namespace WF_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbTalleresContext _context;

        public HomeController(ILogger<HomeController> logger, DbTalleresContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeWithoutLogIn()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
            
        }

        private string GETSha(string sr)
        {
            SHA256 sha = SHA256.Create();
            ASCIIEncoding en = new ASCIIEncoding();

            byte[] bytes = null;

            StringBuilder br = new StringBuilder();

            bytes = sha.ComputeHash(en.GetBytes(sr));

            for (int i = 0; i < bytes.Length; i++)
            {
                br.AppendFormat("{0:x2}", bytes[i]);
            }

            return br.ToString();
        }

        public async Task<IActionResult> Verify(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contra = GETSha(model.Contraseña);
                var nombre = _context.Usuarios.Where(user => user.Codigo == model.Codigo && user.Contraseña == contra).FirstOrDefault();
                if (nombre != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, nombre.Codigo),
                        new Claim(ClaimTypes.Role, "Administrador")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    foreach (var claim in claims)
                    {
                        Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
                    }

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity),authProperties);
                    return RedirectToAction(nameof(Index));
                }                    
                else
                {
                    return View("LogIn",model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                return View("LogIn", model);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
