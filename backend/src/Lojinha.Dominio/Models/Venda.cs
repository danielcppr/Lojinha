using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public double ValorTotal { get; set; }
        public string FormaPagamento { get; set; }

        [Required]
        public List<ItemVenda> ItensVenda { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        [Required]
        public Funcionario FuncionarioVendedor { get; set; }

    }
}
