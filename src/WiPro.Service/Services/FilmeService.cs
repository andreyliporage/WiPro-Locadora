using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;
using WiPro.Domain.Interfaces;

namespace WiPro.Service.Services
{
    public class FilmeService : IFilmeService
    {
        private IRepository<Filme> _repository;

        public FilmeService(IRepository<Filme> repository)
        {
            _repository = repository;
        }

        public async Task<Filme> Get(Guid id)
        {
            return await _repository.GetFilme(id);
        }

        public async Task<IEnumerable<Filme>> GetAll()
        {
            return await _repository.GetFilmes();
        }

        public async Task<Filme> Post(Filme filme)
        {
            return await _repository.InsertAsync(filme);
        }

    }
}