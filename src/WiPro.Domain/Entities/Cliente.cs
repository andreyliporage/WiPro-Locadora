using System.Collections.Generic;

namespace WiPro.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public IEnumerable<Filme> Filmes { get; set; } = new List<Filme>();
    }
}