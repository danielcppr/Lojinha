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
    public class ClienteRepositorio : IClienteRepositorio
    { 
        private readonly LojinhaDbContext _context;
        public ClienteRepositorio(LojinhaDbContext context)
        {
            this._context = context;
        }
    
        public async Task<Cliente> GetClientePorCpfAsync(string cpf)
        {
            Cliente cliente = await _context.Clientes
                .Where(c => c.Cpf == cpf)
                .FirstOrDefaultAsync();

            return cliente;
        }

        public async Task<Cliente> GetClientePorIdAsync(int id)
        {
            Cliente cliente = await _context.Clientes
                .FindAsync(id);

            return cliente;
        }

        public async Task<Cliente[]> GetClientesPorNome(string nome)
        {
            IQueryable<Cliente> query = _context.Clientes
                .Where(c => c.Nome.Contains(nome))
                .OrderBy(c => c.ClienteId);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente[]> GetTodosClientesAsync()
        {
            IQueryable<Cliente> query = _context.Clientes.OrderBy(c => c.Nome);

            return await query.ToArrayAsync();

        }
    }
}
