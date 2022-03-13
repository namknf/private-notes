namespace PrivateNotes.Repositories.Note
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INoteRepository<T>
    {
        T GetNoteById(int id);

        Task<int> Add(T entity);

        List<T> GetAll();
    }
}
