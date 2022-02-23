namespace PrivateNotes.Services
{
    using PrivateNotes.Models;
    using System.Threading.Tasks;

    public class UserRepository<T> : IUserRepository<T> where T: BaseModel
    {
        private readonly PrivateNotesContext _context;

        public UserRepository(PrivateNotesContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
