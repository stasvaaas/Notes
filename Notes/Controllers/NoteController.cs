using Microsoft.AspNetCore.Mvc;
using DAL;
using Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NotesProcessor;
namespace Notes.Controllers
{
    public class NoteController : Controller
    {
        //private readonly NotesContext _db;
        private readonly INotesAccesser _accesser;
        public NoteController(INotesAccesser accesser)
        {

            _accesser = accesser;
        }



        public IActionResult Index()
        {
            IEnumerable<Note> objNotesList = _accesser.GetAll();
            return View(objNotesList);
        }

        public IActionResult Detail(Guid id)
        {
            Note note = _accesser.GetNote(id);

            if (note is null)
                return NotFound();

            return View(note);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note obj)
        {
            if (ModelState.IsValid)
            {
                _accesser.Create(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            Note note = _accesser.GetNote(id);
            return View(note);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note obj)
        {
            if(ModelState.IsValid)
            {
                _accesser.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(Guid id)
        {

            if (id == Guid.Empty)
            {
                return NotFound();
            }
            _accesser.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
