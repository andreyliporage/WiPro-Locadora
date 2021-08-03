using System;
using System.Collections.Generic;

namespace WiPro.Domain.Entities
{
    public class Locacao : BaseEntity
    {
        public Guid ClienteId { get; set; }
        public Guid FilmeId { get; set; }
        public Cliente Cliente { get; set; }
        public Filme Filme { get; set; }
        public DateTime DiaLocao { get; set; }
        public DateTime Devolucao { get; set; }
    }
}