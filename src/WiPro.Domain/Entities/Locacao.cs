using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WiPro.Domain.Entities
{
    public class Locacao : BaseEntity
    {
        public Locacao()
        {
            DiaLocao = DateTime.UtcNow;
            Devolucao = DiaLocao.AddDays(3);
        }

        public Guid ClienteId { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public Filme Filme { get; set; }
        public DateTime DiaLocao { get; set; }
        public DateTime Devolucao { get; set; }
    }
}