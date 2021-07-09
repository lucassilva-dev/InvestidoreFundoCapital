using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Uniciv.Api.Data;
using Uniciv.Api.Models;

namespace Uniciv.Api.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly DataContext _context;

        public FundoCapitalRepository(DataContext context)
        {
            _context = context;
        }

        public void Adicionar(FundoCapital fundo)
        {
            _context.Add(fundo);
            _context.SaveChanges();
        }

        public void Alterar(FundoCapital fundo)
        {
            _context.SaveChangesAsync();
        }

        public IEnumerable<FundoCapital> ListarFundos()
        {
            return _context.FundosCapital;
            
        }

        public FundoCapital ObterPorId(Guid id)
        {
            return _context.FundosCapital.FirstOrDefault(x => x.Id == id);
        }

        public void RemoverFundo(FundoCapital fundo)
        {
            _context.Remove(fundo);
            _context.SaveChanges();
        }   
    }
}