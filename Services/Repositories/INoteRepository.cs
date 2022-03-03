namespace PrivateNotes.Services.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal interface INoteRepository<T>
    {
        T GetNoteById(int id);

        Task<int> Add(T entity);

        List<T> GetAll();
    }
}
