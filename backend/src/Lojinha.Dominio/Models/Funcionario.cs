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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

                return (vendasTotal < 10000) ? SalarioBase + vendasTotal * 0.05 : SalarioBase + vendasTotal * 0.07;
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


                int comissaoPercentual = 0;
                if (vendas.Sum() > 0)
                {
                    comissaoPercentual = (vendas.Sum() < 10000) ? 5 : 7;
                }
                

                return comissaoPercentual;
            }
            private set { }
        }
    
    }
}
