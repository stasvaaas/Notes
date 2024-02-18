using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NotesProcessor;
using DAL;
namespace Notes.Controllers
{
    public class NoteController : Controller
    {
        private readonly INotesProcessor _processor;
        public NoteController(INotesProcessor processor)
        {

            _processor = processor;
        }



        public IActionResult Index()
        {
            IEnumerable<Note> objNotesList = _processor.GetAll();
            return View(objNotesList);
        }

        public IActionResult Detail(Guid id)
        {
            Note note = _processor.GetNote(id);

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
                _processor.Create(obj);
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
            Note note = _processor.GetNote(id);
            return View(note);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note obj)
        {
            if(ModelState.IsValid)
            {
                _processor.Update(obj);
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
            _processor.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
