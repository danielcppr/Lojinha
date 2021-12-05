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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServico _produtoServico;
        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodosProdutos()
        {
            try
            {
                var produtos = await _produtoServico.GetTodosProdutos();

                if (produtos == null) return NotFound("Nenhum produto encontrado");

                return Ok(produtos);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar produtos. Erro: {e.Message}");
            }
        }

        [HttpGet("cod/{codigo}")]
        public async Task<IActionResult> GetProdutoPorCodigo(int codigo)
        {
            try
            {
                var produto = await _produtoServico.GetProdutoPorCodigo(codigo);

                if (produto == null) return NotFound("Nenhum produto encontrado");

                return Ok(produto);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar produto. Erro: {e.Message}");
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetProdutosPorNome(string nome)
        {
            try
            {
                var produtos = await _produtoServico.GetProdutosPorNome(nome);

                if (produtos == null) return NotFound("Nenhum produto encontrado");

                return Ok(produtos);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar produtos. Erro: {e.Message}");
            }
        }




    }
}
