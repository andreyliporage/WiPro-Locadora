using System;
using System.Collections.Generic;

namespace WiPro.Domain.Entities.DTOs
{
    public class LocacaoDTO
    {
        public LocacaoDTO()
        {
            FilmesIds = new List<Guid>();
        }

        public Guid ClienteId { get; set; }
        public IEnumerable<Guid> FilmesIds { get; set; }
    }
}