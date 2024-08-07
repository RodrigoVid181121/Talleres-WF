using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WF_App.Models;

namespace WF_App.Controllers
{
    public class ProductosController : Controller
    {
       

        private readonly ILogger<ProductosController> _logger;
        private readonly DbTalleresContext _context;

        public ProductosController(ILogger<ProductosController> logger, DbTalleresContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);

        }
        // GET para detalles
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.Productos
                .FirstOrDefault(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET Crear
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Codigo,Cantidad,PrecioCosto,PrecioVenta,ModeloVehiculo")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: editar
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Codigo,Cantidad,PrecioCosto,PrecioVenta,ModeloVehiculo")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: borrar
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.Productos
                .FirstOrDefault(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: borrar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = _context.Productos.Find(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
