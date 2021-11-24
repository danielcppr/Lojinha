using Lojinha.Dominio.Models;
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
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioServico _funcionarioServico;

        public FuncionarioController(IFuncionarioServico funcionarioServico)
        {
            _funcionarioServico = funcionarioServico;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodosFuncionarios()
        {
            try
            {
                var funcionarios = await _funcionarioServico.GetFuncionarios();
                if (funcionarios == null) return NotFound("Funcionario não encontrado.");

                return Ok(funcionarios);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar funcionarios. Erro: {e.Message}");
            }
        }

        [HttpGet("matricula/{matricula}")]
        public async Task<IActionResult> GetFuncionarioPorMatricula(int matricula)
        {
            try
            {
                FuncionarioDto func = await _funcionarioServico.GetFuncionarioPorMatricula(matricula);
                return func != null ? Ok(func) : NotFound("Funcionario não encontrado");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar funcionario. Erro: {e.Message}");
            }
        }
    }
}
