using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;
using WiPro.Domain.Entities.DTOs;

namespace WiPro.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(Guid id);
        Task<Cliente> GetCliente(string cpf);
        Task<Filme> GetFilme(Guid id);
        Task<IEnumerable<Filme>> GetFilmes();
        Task<Locacao> GetLocacao(Guid id);
        Task<IEnumerable<Locacao>> GetLocacao();
        Task<Locacao> PutLocacao(Guid idCliente);
        Task<Locacao> PostLocacao(LocacaoDTO locacaoDTO);
        Task<Cliente> InsertCliente(Cliente cliente);
    }
}