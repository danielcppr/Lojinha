using Lojinha.Dominio.Models;
using Lojinha.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        public Task<Cliente[]> GetTodosClientesAsync();
        public Task<Cliente[]> GetClientesPorNome(string nome);
        public Task<Cliente> GetClientePorIdAsync(int id);
        public Task<Cliente> GetClientePorCpfAsync(string cpf);


    }
}
