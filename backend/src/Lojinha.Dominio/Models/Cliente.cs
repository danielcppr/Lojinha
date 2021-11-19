using Lojinha.Dominio.Helpers;
using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        
        [Required]
        [StringLength(25)]
        public string Nome { get; set; }
       
        [Required]
        public string Endereco { get; set; }
        
        [Required]
        [StringLength(11)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [ValidacaoCliente]
        public string Cpf { get; set; }
    }
}
