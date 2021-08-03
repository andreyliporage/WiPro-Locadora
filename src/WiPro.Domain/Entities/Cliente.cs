using System;
using System.Collections.Generic;

namespace WiPro.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {
            Filmes = new HashSet<Filme>();
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public IEnumerable<Filme> Filmes { get; set; } = new List<Filme>();
        public Guid LocacaoId { get; set; }
        public Locacao Locacao { get; set; }
    }
}