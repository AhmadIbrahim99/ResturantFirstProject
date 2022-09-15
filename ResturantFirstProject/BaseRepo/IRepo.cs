using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ResturantFirstProject.BaseRepo
{
    public interface IRepo<T> where T:class, IBase, new()
    {
        Task Add(T entity);
        Task Delete(int id);
        Task Update(int id, T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] icludePropreties);
    }
}
