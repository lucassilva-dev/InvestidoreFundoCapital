using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Uniciv.Api.Models;
using Uniciv.Api.Repositories;

namespace Uniciv.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FundoCapitalController: Controller
    {
        private readonly IFundoCapitalRepository _repositorio;

        public FundoCapitalController(IFundoCapitalRepository repositorio)
        {
            _repositorio = repositorio;
        }
        /// <summary>
        /// Envia os dados de um Fundo Capital
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarFundos()
        {
            return Ok(_repositorio.ListarFundos());
        }

        /// <summary>
        /// Adiciona dados de um fundo capital
        /// </summary>
        /// <param name="fundo">Insira os dados de um fundo logo abaixo</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdicionarFundo([FromBody]FundoCapital fundo)
        {
            _repositorio.Adicionar(fundo);
            return Ok();
        }
        /// <summary>
        /// Altera dados de um fundo capital
        /// </summary>
        /// <param name="id">ID do fundo capital</param>
        /// <param name="fundo">Nome do fundo a ser alterado logo abaixo</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult AlterarFundo(Guid id, [FromBody]FundoCapital fundo)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);
            if (fundoAntigo == null)
            {
                return NotFound();
            }
            fundoAntigo.Nome = fundo.Nome;
            fundoAntigo.ValorAtual = fundo.ValorAtual;
            fundoAntigo.ValorNecessario = fundo.ValorNecessario;
            fundoAntigo.DataResgate = fundo.DataResgate;
            _repositorio.Alterar(fundoAntigo);
            return Ok();
        }

        /// <summary>
        /// Obtem o ID de um Fundo Capital
        /// </summary>
        /// <param name="id">Insira o ID de algum FundoCapital logo abaixo</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);
            if (fundoAntigo == null)
            {
                return NotFound();
            }
            return Ok(fundoAntigo);
        }

        /// <summary>
        /// Ele remove algum Fundo Capital
        /// </summary>
        /// <param name="id">Insira o ID do fundo capital a ser removido abaixo</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult RemoverFundo(Guid id)
        {
            var fundo = _repositorio.ObterPorId(id);
            if (fundo == null)
            {
                return NotFound();
            }
            _repositorio.RemoverFundo(fundo);
            return Ok();
        }
    }
}
