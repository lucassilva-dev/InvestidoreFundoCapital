using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniciv.Api.Models;
using Uniciv.Api.Repositories;

namespace Uniciv.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestidorController : Controller
    {
        private readonly IInvestidorRepository _repositorio;

        public InvestidorController(IInvestidorRepository repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Envia dado(s) do(s) investidor(es)
        /// </summary>
        /// <param>Execute para ver os investidores</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ListarInvestimento()
        {
            return Ok(_repositorio.ListarInvestimento());
        }

        /// <summary>
        /// Adiciona dados de um investidor
        /// </summary>
        /// <param name="investidor">Insira os dados do investidor logo abaixo</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AdicionarInvestidor([FromBody] Investidor investidor)
        {
            _repositorio.Adicionar(investidor);
            return Ok();
        }

        /// <summary>
        /// Atualiza dados de um investidor
        /// </summary>
        /// <param name="id">Identificador do investidor</param>
        /// <param name="investidor">Dados do Investidor a ser alterado logo abaixo</param>
        [HttpPut("{id}")]
        public IActionResult AlterarInvestidor(Guid id, [FromBody] Investidor investidor)
        {
            var investimentoantigo = _repositorio.ObterPorId(id);
            if (investimentoantigo == null)
            {
                return NotFound();
            }
            investimentoantigo.Nome = investidor.Nome;
            investimentoantigo.Perfil = investidor.Perfil;
            _repositorio.Alterar(investimentoantigo);
            return Ok();
        }

        /// <summary>
        /// Recebe Id do investidor
        /// </summary>
        /// <param name="id">Coloque o ID do investidor logo abaixo</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            var investimentoantigo = _repositorio.ObterPorId(id);
            if (investimentoantigo == null)
            {
                return NotFound();
            }
            return Ok(investimentoantigo);
        }
        /// <summary>
        /// Remove dados de um investidor
        /// </summary>
        /// <param name="id">Coloque o ID do investidor a ser removido logo abaixo</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RemoverFundo(Guid id)
        {
            var investidor = _repositorio.ObterPorId(id);
            if (investidor == null)
            {
                return NotFound();
            }
            _repositorio.RemoverInvestidor(investidor);
            return Ok();
        }


    }


    }

