using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.DTOs
{
    public class FuncionarioDto
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public double SalarioBase { get; set; }
        //public virtual List<VendaDto> Vendas { get; set; }
        public double TotalEmVendas { get; set; }
        public double SalarioTotal { get; set; }
        public int PercentualComissao { get; set; }
    }
}
