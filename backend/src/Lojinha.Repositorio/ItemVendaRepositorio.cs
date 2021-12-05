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
    public class ItemVendaRepositorio : IItemVendaRepositorio
    {
        public readonly LojinhaDbContext _context;
        public ItemVendaRepositorio(LojinhaDbContext context)
        {
            _context = context;
        }

        public async Task<ItemVenda> GetItemVenda(int itemVendaId)
        {
            return await _context.ItensVendas.Include(i => i.Produto)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync(i => i.ItemVendaId.Equals(itemVendaId));
        }

        public async Task<ItemVenda[]> GetItensVendaPorVendaId(int vendaId)
        {
            return await _context.ItensVendas.Include(i => i.Produto)
                                             .AsNoTracking()
                                             .Where(i => i.Venda.VendaId == vendaId)
                                             .ToArrayAsync();
        }

        public async Task<ItemVenda[]> GetTodosItensVendaAsync()
        {
            return await _context.ItensVendas.Include(i => i.Produto)
                                             .AsNoTracking()
                                             .ToArrayAsync();
        }

    }
}
