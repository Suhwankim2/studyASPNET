using Microsoft.AspNetCore.Mvc;
using BoardWebApp.Models;
using BoardWebApp.data;

namespace BoardWebApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           IEnumerable<Note> list = _context.Notes.ToList();
            return View(list);
        }
    }
}
