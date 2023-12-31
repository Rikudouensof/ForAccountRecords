using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.IRepository
{
    public interface IGenericRepository<T, K> where T : class
    {

        Task<IEnumerable<T>> All();

        Task<T> GetById(K id);

        Task<bool> Add(T entity);

        Task<bool> Delete(K id);

        Task<bool> Update(T entity);

    }
}
