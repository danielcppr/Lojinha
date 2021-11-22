using Lojinha.Servico.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.Interfaces
{
    public interface IVendaServico
    {
        public Task<VendaDto[]> GetTodasVendas();
        public Task<VendaDto[]> GetVendasPorIdCliente(int id);
        public Task<VendaDto[]> GetVendasPorMatriculaFuncionario(int matricula);
        public Task<VendaDto> GetVendaPorId(int id);
        public Task<bool> AdicionarVenda(VendaDto venda);
        public Task<bool> AdicionarItemVenda(int vendaId, ItemVendaDto itemVenda);
        public Task<bool> AtualizaVenda(int vendaId, VendaDto venda);
    }
}
