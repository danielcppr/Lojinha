using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.DTOs
{
    public class ItemVendaDto
    {
        public int ItemVendaId { get; set; }
        public int Quantidade { get; set; }
        public double ValorParcial { get; set; }
        public int ProdutoCodigo { get; set; }
        public int VendaId { get; set; }
    }
}
