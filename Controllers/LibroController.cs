using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using T3_Grupo4.Datos;
using T3_Grupo4.Models;

namespace T3_Grupo4.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibroController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var libros = await _context.Libros.ToListAsync();
            return View(libros);
        }

        [Authorize]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return View(libro);
            }

            _context.Add(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return BadRequest("El ID es nulo.");
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound("Libro no encontrado.");
            }

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest("ID del libro no coincide.");
            }

            if (!ModelState.IsValid)
            {
                return View(libro);
            }

            try
            {
                _context.Update(libro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExiste(libro.Id))
                {
                    return NotFound("El libro no existe.");
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return BadRequest("El ID es nulo.");
            }

            var libro = await _context.Libros.FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound("Libro no encontrado.");
            }

            return View(libro);
        }

        // POST: Libro/Eliminar/{id}
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound("Libro no encontrado para eliminar.");
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExiste(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
