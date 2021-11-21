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

        public double ValorTotal { get; set; }
        public string FormaPagamento { get; set; }

        public virtual List<ItemVenda> ItensVenda { get; set; }
        
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        
        [Required]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("FuncionarioMatricula")]
        public int FuncionarioMatricula { get; set; }
        
        [Required]
        public virtual Funcionario Funcionario { get; set; }

        //public void calculaValorTotal(double _valorTotal = 0)
        //{

        //    try
        //    {
        //        //ItensVenda.ForEach(i => _valorTotal += i.Valor);
            
        //        ValorTotal = 10;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }
        //}



    }
}
