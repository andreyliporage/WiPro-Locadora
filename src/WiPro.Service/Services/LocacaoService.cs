using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;
using WiPro.Domain.Entities.DTOs;
using WiPro.Domain.Interfaces;

namespace WiPro.Service.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly IRepository<Locacao> _repository;

        public LocacaoService(IRepository<Locacao> repository)
        {
            _repository = repository;
        }

        public async Task<Locacao> Get(Guid id)
        {
            return await _repository.GetLocacao(id);
        }

        public async Task<IEnumerable<Locacao>> GetAll()
        {
            return await _repository.GetLocacao();
        }

        public async Task<Locacao> Post(LocacaoDTO locacaoDTO)
        {
            return await _repository.PostLocacao(locacaoDTO);
        }
    }
}