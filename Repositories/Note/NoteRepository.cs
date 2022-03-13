namespace PrivateNotes.Repositories.Note
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PrivateNotes.Data;
    using PrivateNotes.Models;

    public class NoteRepository<T> : INoteRepository<T>
        where T : BaseModel
    {
        private readonly PrivateNotesContext _context;

        public NoteRepository(PrivateNotesContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public T GetNoteById(int id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            return result;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
