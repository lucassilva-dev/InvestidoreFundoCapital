using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uniciv.Api.Models
{
    public class Investidor
    {
        public Investidor()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string Nome { get; set; }
        public string Perfil { get; set; }
    }
}

