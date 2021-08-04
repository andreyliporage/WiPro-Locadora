using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;

namespace WiPro.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(Guid id);
        Task<Filme> GetFilme(Guid id);
        Task<IEnumerable<Filme>> GetFilmes();
        Task<Locacao> GetLocacao(Guid id);
        Task<Cliente> InsertCliente(Cliente cliente);
    }
}