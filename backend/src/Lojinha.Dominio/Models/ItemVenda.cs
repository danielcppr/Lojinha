using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Models
{
    public class ItemVenda
    {
        public int ItemVendaId { get; set; }
        public int Quantidade { get; set; }

        public double ValorParcial { get; set; }

        [Required]
        [JsonInclude]
        public virtual Produto Produto { get; set; }

        [Required]
        [JsonIgnore]
        public virtual Venda Venda { get; set; }


    }   

}
