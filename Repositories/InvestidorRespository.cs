using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Uniciv.Api.Data;
using Uniciv.Api.Models;

namespace Uniciv.Api.Repositories
{
    public class InvestidorRepository : IInvestidorRepository
    {
        private readonly DataContext _context;

        public InvestidorRepository(DataContext context)
        {
            _context = context;
        }

        public void Adicionar(Investidor investir)
        {
            _context.Add(investir);
            _context.SaveChanges();
        }

        public void Alterar(Investidor investir)
        {
            _context.SaveChangesAsync();
        }

        public IEnumerable<Investidor> ListarInvestimento()
        {
            return _context.Investidores;

        }

        public Investidor ObterPorId(Guid id)
        {
            return _context.Investidores.FirstOrDefault(x => x.Id == id);
        }

        public void RemoverInvestidor(Investidor investir)
        {
            _context.Remove(investir);
            _context.SaveChanges();
        }
    }
}
