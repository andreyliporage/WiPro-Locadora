using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WiPro.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Guid LocacaoId { get; set; }
        public Locacao Locacao { get; set; }
    }
}