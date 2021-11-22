using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio.Interfaces
{
    public interface IItemVendaRepositorio
    {
        public Task<ItemVenda[]> GetTodosItensVendaAsync();
        public Task<ItemVenda[]> GetItensVendaPorVendaId(int vendaId);
        public Task<ItemVenda> GetItemVenda (int itemVendaId);

    }
}
