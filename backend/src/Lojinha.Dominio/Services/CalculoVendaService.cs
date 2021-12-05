using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Services
{
    public class CalculoVendaService
    {
        public static double CalculaValorTotal(Venda venda)
        {
            double valorTotal = 0;
            List<ItemVenda> itensVenda = venda.ItensVenda;
            itensVenda.ForEach(i => valorTotal += i.ValorParcial);

            return valorTotal;
        }


    }
}
