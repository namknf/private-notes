namespace PrivateNotes.Services
{
    using System.Threading.Tasks;

    internal interface IUserRepository<T>
    {
        T GetById(int id);

        Task<int> Add(T entity);
    }
}
