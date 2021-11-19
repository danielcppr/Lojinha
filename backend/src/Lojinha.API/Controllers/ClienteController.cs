using Lojinha.Dominio.Models;
using Lojinha.Servico;
using Lojinha.Servico.DTOs;
using Lojinha.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodosClientes()
        {
            try
            {
                var clientes = await _clienteServico.GetTodosClientes();
                if (clientes == null) return NotFound("Cliente não encontrado.");

                return Ok(clientes);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar clientes. Erro: {e.Message}");
            }
        }
        
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetClientePorId(int id)
        {
            try
            {
                var clientes = await _clienteServico.GetClientePorId(id);
                if (clientes == null) return NotFound($"Cliente com id {id} não encontrado.");

                return Ok(clientes);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar cliente. Erro: {e.Message}");
            }
        }
        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetClientePorCpf(string cpf)
        {
            try
            {
                var clientes = await _clienteServico.GetClientePorCpf(cpf);
                if (clientes == null) return NotFound($"Cliente com cpf {cpf} não encontrado.");

                return Ok(clientes);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar cliente. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] ClienteDto clienteModel)
        {
            try
            {
                return await _clienteServico.AddCliente(clienteModel) ? Ok() : BadRequest("Erro ao cadastrar cliente");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar cadastrar cliente. Erro: {e.Message}");
            }
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                return await _clienteServico.RemoveCliente(id) ? Ok() : BadRequest("Erro ao remover cliente");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar remover cliente. Erro: {e.Message}");
            }
        }

        [HttpPut("cpf/{cpf}")]
        public async Task<IActionResult> AtualizaCliente(string cpf, ClienteDto clienteNovo)
        {
            try
            {
                return await _clienteServico.AtualizaCliente(cpf, clienteNovo) ? Ok() : BadRequest("Erro ao editar cliente");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar editar cliente. Erro: {e.Message}");
            }

        }
    
    }
}
