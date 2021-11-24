using Lojinha.Dominio.Models;
using Lojinha.Servico.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.Interfaces
{
    public interface IFuncionarioServico
    {
        public Task<FuncionarioDto[]> GetFuncionarios();
        public Task<FuncionarioDto> GetFuncionarioPorMatricula(int matricula);
    }
}
