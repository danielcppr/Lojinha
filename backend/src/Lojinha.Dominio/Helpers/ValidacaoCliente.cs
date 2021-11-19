using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lojinha.Dominio.Helpers
{
    public class ValidacaoCliente : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cliente = (Cliente)validationContext.ObjectInstance;

            if (!Regex.IsMatch($"{cliente.Cpf.Trim()}", "^[0-9]+$"))
            {
                return new ValidationResult("O cpf deve conter apenas dígitos.");
            }
            
            if (!Regex.IsMatch($"{cliente.Telefone.Trim()}", "^[0-9]+$"))
            {
                return new ValidationResult("O número de telefone deve conter apenas dígitos.");
            }

            return ValidationResult.Success;



        }
    }
}
