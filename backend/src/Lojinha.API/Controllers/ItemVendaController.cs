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
    public class ItemVendaController : ControllerBase
    {
        private readonly IItemVendaServico _itemVendaServico;
        public ItemVendaController(IItemVendaServico itemVendaServico)
        {
            _itemVendaServico = itemVendaServico;
        }


        [HttpGet]
        public async Task<IActionResult> GetTodosItens()
        {
            try
            {
                var itensVenda = await _itemVendaServico.GetTodosItensVendaAsync();

                return itensVenda != null ? Ok(itensVenda) : NotFound("Nenhum item encontrado"); 
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Houve um erro ao tentar retornar itens. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItemVenda([FromBody] ItemVendaDto model)
        {
            try
            {
                return await _itemVendaServico.AddItemVenda(model) ? Ok() : BadRequest("Erro ao cadastrar item");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Houve um erro ao tentar cadastrar Item. Erro: {e.Message}");
            }
        }

    }
}
