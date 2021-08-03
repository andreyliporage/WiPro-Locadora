using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;

namespace WiPro.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
    }
}