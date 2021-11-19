using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class ItemVenda
    {
        public int ItemVendaId { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }

        [Required]
        public Produto Produto { get; set; }

        [Required]
        public Venda Venda { get; set; }
    }
}
