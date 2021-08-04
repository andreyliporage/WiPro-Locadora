using System;
using System.Text.Json.Serialization;

namespace WiPro.Domain.Entities
{
    public class Filme : BaseEntity
    {
        public Filme()
        {
            Disponivel = true;
        }

        public string Nome { get; set; }
        public string Genero { get; set; }
        public bool Disponivel { get; set; }
        public Guid LocacaoId { get; set; }

        [JsonIgnore]
        public Locacao Locacao { get; set; }
    }
}