using Lojinha.Dominio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class Funcionario
    {
        // Já com relação ao funcionário, é preciso conhecer sua
        // matrícula, nome, endereço, telefone, cpf e salário base.
        // O cálculo do salário do funcionário está relacionado a
        // uma comissão que feita sobre o volume total de vendas no mês.
        // O percentual a ser aplicado é de 5% para volume de vendas
        // inferior o R$ 10 mil reais e 7% para valor maior ou igual a R$ 10 mil reais.

        [Key]
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        [JsonIgnore]
        public virtual List<Venda> Vendas { get; set; }
        public double SalarioBase { get; set; }

        [NotMapped]
        public double TotalEmVendas 
        {
            get
            {
                double total = 0;
                Vendas.ForEach(v => total += v.ValorTotal);
                return total;
            }
            private set { }
        }
        
        [NotMapped]
        public double SalarioTotal
        { 
            get
            {
                var query = (from v in Vendas
                             select v.ValorTotal);

                double vendasTotal = query.Sum();

                return (vendasTotal < 10000) ? SalarioBase + vendasTotal * 1.005 : SalarioBase + vendasTotal * 1.007;
            }
            private set { }
        }
    
        [NotMapped]
        public int PercentualComissao
        {
            get
            {
                var vendas = (from v in Vendas
                              select v.ValorTotal);

                int comissaoPercentual = (vendas.Sum() < 10000) ? 5 : 7;

                return comissaoPercentual;
            }
            private set { }
        }
    
    }
}
