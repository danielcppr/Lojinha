using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao{ get; set; }
        public double Valor { get; set; }
        public int QtdEstoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public DateTime Validade { get; set; }

        //public IEnumerable<ItemVenda> ItensVendas { get; set; }

    }
}
