using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Core
{
    public interface IGenericRepository<T>
    {
        Task<T> AddAsync(T entity);

        void Update(T entity);

        void Remove(T entity);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<T> GetById(int id);
    }
}