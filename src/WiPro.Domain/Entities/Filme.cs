using System;

namespace WiPro.Domain.Entities
{
    public class Filme : BaseEntity
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public bool Disponivel { get; set; }
    }
}