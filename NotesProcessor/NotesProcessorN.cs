using DAL;
using Models;

namespace NotesProcessor
{
    public class NotesProcessorN : INotesProcessor
    {

        private readonly NotesContext _repository;

        public NotesProcessorN(NotesContext context)
        {
            _repository = context;
        }

        public IList<Note> GetNotesByPriority(int priority)
        {
            return _repository.Notes.OrderByDescending(x => x.Priority).ToList();
        }

    }
}
