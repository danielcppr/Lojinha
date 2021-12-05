using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.DTOs
{
    public class ProdutoDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int QtdEstoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public string Validade { get; set; }
    }
}
