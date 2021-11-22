using Lojinha.Servico.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.Interfaces
{
    public interface IItemVendaServico
    {
        public Task<ItemVendaDto[]> GetTodosItensVendaAsync();
        public Task<ItemVendaDto[]> GetItensVendaPorVendaId(int vendaId);
        public Task<ItemVendaDto> GetItemVenda(int id);
        public Task<bool> AddItemVenda(ItemVendaDto model);
    }
}
