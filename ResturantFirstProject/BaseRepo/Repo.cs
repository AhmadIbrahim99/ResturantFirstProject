using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ResturantFirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ResturantFirstProject.BaseRepo
{
    public class Repo<T> : IRepo<T> where T :class, IBase, new()
    {
        private readonly ResturantDBContext _context;
        public Repo(ResturantDBContext context)
        {
            _context = context;
        }

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry= _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()=> await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] icludePropreties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = icludePropreties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)=> await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task Update(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
