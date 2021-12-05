using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio.Interfaces
{
    public interface IVendaRepositorio
    {
        public Task<Venda[]> GetTodasVendas();
        public Task<Venda[]> GetVendasPorIdCliente(int id);
        public Task<Venda[]> GetVendasPorMatriculaFuncionario(int matricula);
        public Task<Venda> GetVendaPorId(int id);

    }
}
