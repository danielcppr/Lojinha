using Lojinha.Dominio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class Venda
    {
        double _valorTotal = 0;
        public int VendaId { get; set; }
        public virtual List<ItemVenda> ItensVenda { get; set; } 

        [NotMapped]
        public double ValorTotal
        {
            get
            {
                double valor = 0;
                ItensVenda.ForEach(i => valor += i.ValorParcial);
                return valor;
            }
            set { }
        }

        public string FormaPagamento { get; set; }

        
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        
        [Required]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("FuncionarioMatricula")]
        public int FuncionarioMatricula { get; set; }
        
        [Required]
        public virtual Funcionario Funcionario { get; set; }

        //public static double CalculaValorTotal(List<ItemVenda> itensVenda)
        //{
        //    double valorTotal = 0;
        //    ItensVenda.ForEach(i => valorTotal += i.ValorParcial);

        //    return valorTotal;
        //}

        //public void CalculaValorTotal()
        //{
        //    ValorTotal = 0;
        //    ItensVenda.ForEach(i => ValorTotal += i.ValorParcial);
        //}


    }
}
