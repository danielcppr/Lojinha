using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        public Task<Funcionario[]> GetTodosFuncionariosAsync();
        public Task<Funcionario[]> GetFuncionariosPorNomeAsync(string nome);
        public Task<Funcionario> GetFuncionarioPorMatriculaAsync(int id);
        public Task<Funcionario> GetFuncionarioPorCpfAsync(string cpf);
    }
}
