using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.DTOs
{
    public class VendaDto
    {
        public int VendaId { get; set; }
        public double ValorTotal { get ; set ; }
        public string FormaPagamento { get; set; }
        public List<ItemVendaDto> ItensVenda { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioMatricula { get; set; }
    }
}
