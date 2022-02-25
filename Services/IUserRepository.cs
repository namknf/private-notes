namespace PrivateNotes.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal interface IUserRepository<T>
    {
        T GetById(int id);

        Task<int> Add(T entity);

        List<T> GetAll();
    }
}
