using Lojinha.Dominio.Models;
using Lojinha.Servico.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.Interfaces
{
    public interface IClienteServico
    {
        public Task<bool> AddCliente(ClienteDto cliente);
        public Task<bool> RemoveCliente(int id);
        public Task<ClienteDto[]> GetTodosClientes();
        public Task<ClienteDto> GetClientePorId(int id);
        public Task<ClienteDto> GetClientePorCpf(string cpf);
        //public Task<Cliente[]> GetClientesPorNome();
        public Task<bool> AtualizaCliente(string cpf, ClienteDto clienteNovo);
    }
}
