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
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly LojinhaDbContext _context;

        public ProdutoRepositorio(LojinhaDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetProdutoPorCodigo(int codigo)
        {
            return await _context.Produtos
                .FindAsync(codigo);
        }

        public async Task<Produto[]> GetProdutosPorNome(string nome)
        {
            IQueryable<Produto> query = _context.Produtos
                                            .Where(p => p.Nome.Contains(nome))
                                            .OrderBy(p => p.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Produto[]> GetTodosProdutos()
        {
            return await _context.Produtos
                                 .ToArrayAsync();
        }
    }
}
