using Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Newtonsoft.Json;

namespace DAL
{
    public class NotesAccesser : INotesAccesser
    {
        
        private readonly NotesContext _db;

        public NotesAccesser(NotesContext context)
        {
            _db = context;
        }

        public IEnumerable<Note> GetAll()
        {
            return _db.Notes.ToList();
        }

        public void Create(Note obj)
        {
            _db.Notes.Add(obj);
            _db.SaveChanges();
        }

        public Note GetNote(Guid id)
        {
            return _db.Notes.Find(id);
        }

        public void Update(Note note)
        {
            _db.Entry(note).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Note note = GetNote(id);
            if (note != null)
            {
                _db.Notes.Remove(note);
                _db.SaveChanges();
            }
        }

    }
}
