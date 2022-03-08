using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Core
{
    public interface IGenericService<T>
    {
        Task<T> AddAsync(T entity);

        Task Update(T entity);

        Task Remove(T entity);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<T> GetById(int id);
    }
}