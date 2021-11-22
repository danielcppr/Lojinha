using AutoMapper;
using Lojinha.Dominio.Models;
using Lojinha.Dominio.Services;
using Lojinha.Repositorio.Interfaces;
using Lojinha.Servico.DTOs;
using Lojinha.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico
{
    public class ItemVendaServico : IItemVendaServico
    {
        private readonly IVendaServico _vendaServico;
        private readonly IItemVendaRepositorio _itemVendaRepo;
        private readonly ICrudGenericoRepositorio _genericoRepo;
        private readonly IMapper _mapper;

        public ItemVendaServico(IItemVendaRepositorio itemVendaRepo, ICrudGenericoRepositorio genericoRepo, IMapper mapper, IVendaServico vendaServico)
        {
            _vendaServico = vendaServico;
            _itemVendaRepo = itemVendaRepo;
            _genericoRepo = genericoRepo;
            _mapper = mapper;
        }
        public async Task<ItemVendaDto> GetItemVenda(int id)
        {
            try
            {
                var itemVenda = await _itemVendaRepo.GetItemVenda(id);
                if (itemVenda == null) return null;

                var itemVendaMapped = _mapper.Map<ItemVendaDto>(itemVenda);
                
                return itemVendaMapped;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ItemVendaDto[]> GetItensVendaPorVendaId(int vendaId)
        {
            try
            {
                var itensVenda = await _itemVendaRepo.GetItensVendaPorVendaId(vendaId);
                if (itensVenda == null) return null;

                var itensVendaMapped = _mapper.Map<ItemVendaDto[]>(itensVenda);

                return itensVendaMapped;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ItemVendaDto[]> GetTodosItensVendaAsync()
        {
            try
            {
                var itensVenda = await _itemVendaRepo.GetTodosItensVendaAsync();
                if (itensVenda == null) return null;

                var itensVendaMapped = _mapper.Map<ItemVendaDto[]>(itensVenda);

                return itensVendaMapped;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AddItemVenda(ItemVendaDto model)
        {
            try
            {
                var itemVendaMapped = _mapper.Map<ItemVenda>(model);

                _genericoRepo.Add(itemVendaMapped);

                if (await _genericoRepo.SaveChangesAsync())
                {
                    var venda = await _vendaServico.GetVendaPorId(itemVendaMapped.VendaId);
                    var vendaMapped = _mapper.Map<Venda>(venda);

                    double valorTotal = CalculoVendaService.CalculaValorTotal(vendaMapped);
                    
                    venda.ValorTotal = valorTotal;

                    
                    return await _vendaServico.AtualizaVenda(venda.VendaId, venda) ? true : false;

                    

                }
                else
                {
                    throw new Exception("Houve algum erro ao cadastrar novo Item.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
