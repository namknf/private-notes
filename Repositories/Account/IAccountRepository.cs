namespace PrivateNotes.Repositories.Account
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal interface IAccountRepository<T>
    {
        T GetById(string id);

        Task<string> Add(T entity);

        List<T> GetAll();
    }
}
