using Library_System.Models;
using Library_System.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Repo.Implmentation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly My_AppContext _context;
        private readonly DbSet<T> db;

        public GenericRepo(My_AppContext context)
        {
            _context = context;
            db = context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await db.AddAsync(entity);

        }

        public void Delete(T entity)
        {
            db.Remove(entity);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await db.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await db.FindAsync(id);
        }
    }
}
