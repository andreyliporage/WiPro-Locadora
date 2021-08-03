using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;

namespace WiPro.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> Get(Guid id);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> Post(Cliente cliente);
    }
}