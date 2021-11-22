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
    public class VendaRepositorio : IVendaRepositorio
    {
        private readonly LojinhaDbContext _context;
        public VendaRepositorio(LojinhaDbContext context)
        {
            _context = context;
        }

        public async Task<Venda[]> GetTodasVendas()
        {
            return await _context.Vendas
                                 .Include(v => v.Cliente)
                                 .Include(v => v.Funcionario)
                                 .Include(v => v.ItensVenda)
                                 .ToArrayAsync();
        }

        public async Task<Venda> GetVendaPorId(int id)
        {
            return await _context.Vendas
                                 .Include(v => v.ItensVenda)
                                 .Where(v => v.VendaId == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<Venda[]> GetVendasPorIdCliente(int id)
        {
            IQueryable<Venda> query = _context.Vendas.Where(v => v.Cliente.ClienteId == id);

            return await query.Include(v => v.ItensVenda).ThenInclude(i => i.Produto)
                                 .ToArrayAsync();

        }

        public async Task<Venda[]> GetVendasPorMatriculaFuncionario(int matricula)
        {
            IQueryable<Venda> query = _context.Vendas.Where(v => v.Funcionario.Matricula == matricula);

            return await query.ToArrayAsync();
        }
    }
}
