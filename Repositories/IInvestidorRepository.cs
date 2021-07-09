using System;
using System.Collections.Generic;
using Uniciv.Api.Models;

namespace Uniciv.Api.Repositories
{
    public interface IInvestidorRepository
    {
        void Adicionar(Investidor investir);
        void Alterar(Investidor investir);
        IEnumerable<Investidor> ListarInvestimento();
        Investidor ObterPorId(Guid id);
        void RemoverInvestidor(Investidor investir);


    }
}
