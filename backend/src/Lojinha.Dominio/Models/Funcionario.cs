using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class Funcionario
    {
        // Já com relação ao funcionário, é preciso conhecer sua
        // matrícula, nome, endereço, telefone, cpf e salário base.
        // O cálculo do salário do funcionário está relacionado a
        // uma comissão que feita sobre o volume total de vendas no mês.
        // O percentual a ser aplicado é de 5% para volume de vendas
        // inferior o R$ 10 mil reais e 7% para valor maior ou igual a R$ 10 mil reais.

        [Key]
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public double SalarioBase { get; set; }
        public IEnumerable<Venda> Vendas { get; set; }
    }
}
