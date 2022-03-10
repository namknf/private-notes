namespace PrivateNotes.Services.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal interface IUserRepository<T>
    {
        T GetById(string id);

        Task<string> Add(T entity);

        List<T> GetAll();
    }
}
