using Lojinha.Servico.DTOs;
using Lojinha.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaServico _vendaServico;
        public VendaController(IVendaServico vendaServico)
        {
            _vendaServico = vendaServico;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodasVendas()
        {
            try
            {
                var vendas = await _vendaServico.GetTodasVendas();

                if (vendas == null) return NotFound("Nenhuma venda encontrada");

                return Ok(vendas);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar vendas. Erro: {e.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetVendaPorId(int id)
        {
            try
            {
                var venda = await _vendaServico.GetVendaPorId(id);

                if (venda == null) return NotFound("Nenhuma venda encontrada");

                return Ok(venda);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar venda. Erro: {e.Message}");
            }
        }

        [HttpGet("cliente/{id}")]
        public async Task<IActionResult> GetVendasPorIdCliente(int id)
        {
            try
            {
                var vendas = await _vendaServico.GetVendasPorIdCliente(id);
                if (vendas == null) return NotFound($"Nenhuma venda encontrada para o id {id}");

                return Ok(vendas);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar vendas. Erro: {e.Message}");
            }
        }

        [HttpGet("vendedor/{id}")]
        public async Task<IActionResult> GetVendasPorIdVendedor (int id)
        {
            try
            {
                var vendas = await _vendaServico.GetVendasPorMatriculaFuncionario(id);
                if (vendas == null) return NotFound($"Nenhuma venda encontrada para o vendedor {id}");

                return Ok(vendas);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar vendas. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVenda([FromBody] VendaDto vendaModel)
        {
            try
            {
                return await _vendaServico.AdicionarVenda(vendaModel) ? Ok() : BadRequest("Erro ao cadastrar cliente");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar cadastrar cliente. Erro: {e.Message}");
            }
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> AddItemVenda([FromBody] ItemVendaDto itemVendaModel, int id)
        {
            try
            {
                return await _vendaServico.AdicionarItemVenda(id, itemVendaModel) ? Ok() : BadRequest("Erro ao adicionar item venda");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar cadastrar item venda. Erro: {e.Message}"); ;
            }
        }

    }
}
