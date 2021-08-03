using System;
using System.Threading.Tasks;
using WiPro.Domain.Entities;

namespace WiPro.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<T> SelectAsync(Guid id);
        Task<T> SelectAsync();
    }
}