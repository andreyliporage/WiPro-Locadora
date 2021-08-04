using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiPro.Domain.Entities;

namespace WiPro.Domain.Interfaces
{
    public interface IFilmeService
    {
        Task<Filme> Get(Guid id);
        Task<IEnumerable<Filme>> GetAll();
        Task<Filme> Post(Filme cliente);
    }
}