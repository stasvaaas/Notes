using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesProcessor
{
    public interface INotesProcessor
    {
        public void Create(Note note);
        public Note GetNote(Guid id);
        public void Update(Note note);
        public void Delete(Guid id);
        public IEnumerable<Note> GetAll();
    }
}
