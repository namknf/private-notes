
namespace PrivateNotes.Services.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using PrivateNotes.Models;

    public class UserRepository<T> : IUserRepository<T>
        where T : IdentityUser
    {
        private readonly PrivateNotesContext _context;

        public UserRepository(PrivateNotesContext context)
        {
            _context = context;
        }

        public async Task<string> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public T GetById(string id)
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
