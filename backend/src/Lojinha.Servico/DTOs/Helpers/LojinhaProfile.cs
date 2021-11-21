using AutoMapper;
using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.DTOs.Helpers
{
    public class LojinhaProfile : Profile
    {
        public LojinhaProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<Venda, VendaDto>();
            CreateMap<ItemVenda, ItemVendaDto>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDto>().ReverseMap();
        }
    }
}
