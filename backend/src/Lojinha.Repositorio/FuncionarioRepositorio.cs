using Lojinha.Dominio.Models;
using Lojinha.Repositorio.Contexto;
using Lojinha.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly LojinhaDbContext _context;

        public FuncionarioRepositorio(LojinhaDbContext context)
        {
            _context = context;
        }
        public Task<Funcionario> GetFuncionarioPorCpfAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public async Task<Funcionario> GetFuncionarioPorMatriculaAsync(int id)
        {
            return await _context.Funcionarios.Include(f => f.Vendas)
                                              .ThenInclude(v => v.ItensVenda)
                                              .ThenInclude(i => i.Produto)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync(i => i.Matricula == id);
        }

        public Task<Funcionario[]> GetFuncionariosPorNomeAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public async Task<Funcionario[]> GetTodosFuncionariosAsync()
        {
            return await _context.Funcionarios.Include(f => f.Vendas).ThenInclude(v => v.ItensVenda).ThenInclude(i => i.Produto).AsNoTracking().ToArrayAsync();
        }
    }
}
