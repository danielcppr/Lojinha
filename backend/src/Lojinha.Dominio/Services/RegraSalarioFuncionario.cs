using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Services
{
    public class RegraSalarioFuncionario
    {
        public static double CalculoSalario(Funcionario funcionario)
        {
            var query = (from v in funcionario.Vendas
                         select v.ValorTotal);

            double vendasTotal = query.Sum();

            return (vendasTotal < 10000) ? vendasTotal * 1.005 : vendasTotal * 1.007;
        }
        public static int CalculaComissao(Funcionario funcionario)
        {
            var vendas = (from v in funcionario.Vendas
                         select v.ValorTotal);

            int comissaoPercentual = (vendas.Sum() < 10000) ? 5 : 7;

            return comissaoPercentual;
        }
        public static double TotalVendasPeriodo(Funcionario funcionario)
        {
            double total = 0;
            foreach (var vendas in funcionario.Vendas)
            {
                total += vendas.ValorTotal;
            }
            return total;
        }
    }
}
