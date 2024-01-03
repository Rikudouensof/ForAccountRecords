using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.IRepository
{
    public interface IGenericRepository<T, K> where T : class
    {

        Task<IEnumerable<T>> All(BaseRequestModel userData);

        Task<T> GetById(K id, BaseRequestModel userData);

        Task<bool> Add(T entity, BaseRequestModel userData);

        Task<bool> Delete(K id, BaseRequestModel userData);

        Task<bool> Update(T entity, BaseRequestModel userData);

    }
}
