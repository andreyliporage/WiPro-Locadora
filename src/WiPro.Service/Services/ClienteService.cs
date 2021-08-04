using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;
using WiPro.Domain.Interfaces;

namespace WiPro.Service.Services
{
    public class ClienteService : IClienteService
    {
        private IRepository<Cliente> _repository;

        public ClienteService(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> Get(Guid id)
        {
            return await _repository.GetCliente(id);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _repository.GetClientes();
        }

        public async Task<Cliente> Post(Cliente cliente)
        {
            return await _repository.InsertCliente(cliente);
        }
    }
}