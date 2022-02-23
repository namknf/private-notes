namespace PrivateNotes.Services
{
    using System.Threading.Tasks;

    interface IUserRepository<T>
    {
        Task<int> Add(T entity);
    }
}
