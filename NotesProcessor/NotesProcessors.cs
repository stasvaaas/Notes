using DAL;
using Models;

namespace NotesProcessor
{
    public class NotesProcessors : INotesProcessor
    {

        private readonly INotesAccesser _repository;

        public NotesProcessors(INotesAccesser repository)
        {
            _repository = repository;
        }

        public void Create(Note note)
        {
            _repository.Create(note);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Note> GetAll()
        {
           return _repository.GetAll();
        }

        public Note GetNote(Guid id)
        {
            return _repository.GetNote(id);
        }

        public void Update(Note note)
        {
            _repository.Update(note);
        }
    }
}
