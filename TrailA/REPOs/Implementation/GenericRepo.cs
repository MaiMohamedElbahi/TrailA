using Microsoft.EntityFrameworkCore;
using TrailA.Data;
using TrailA.REPOs.Interface;

namespace TrailA.REPOs.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(T item)
        {
           await context.Set<T>().AddAsync(item);
        }

        public async Task Delete(T item)
        {
            context.Set<T>().Remove(item);
        }

        public async Task<T> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task Update(T item)
        {
            context.Update(item);
        }
    }
}
