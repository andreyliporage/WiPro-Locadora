using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;
using WiPro.Domain.Entities.DTOs;

namespace WiPro.Domain.Interfaces
{
    public interface ILocacaoService
    {
        Task<Locacao> Get(Guid id);
        Task<IEnumerable<Locacao>> GetAll();
        Task<Locacao> Post(LocacaoDTO locacaoDTO);
    }
}