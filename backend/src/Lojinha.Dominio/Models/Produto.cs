using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao{ get; set; }
        public double Valor { get; set; }
        public int QtdEstoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public string Validade { get; set; }


        //public IEnumerable<ItemVenda> ItensVendas { get; set; }

    }
}
