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
    public class VendaServico : IVendaServico
    {
        private readonly IVendaRepositorio _vendaRepo;
        private readonly ICrudGenericoRepositorio _genericoRepo;
        private readonly IMapper _mapper;

        public VendaServico(ICrudGenericoRepositorio genericoRepo, IVendaRepositorio vendaRepositorio, IMapper mapper)
        {
            _vendaRepo = vendaRepositorio;
            _genericoRepo = genericoRepo;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarVenda(VendaDto venda)
        {
            try
            {
                var vendaMapped = _mapper.Map<Venda>(venda);

                //vendaMapped.ValorTotal = CalculoVendaService.CalculaValorTotal(vendaMapped);

                _genericoRepo.Add(vendaMapped);

                return await _genericoRepo.SaveChangesAsync() ? true : throw new Exception("Houve algum erro ao realizar a venda.");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<VendaDto[]> GetTodasVendas()
        {
            try
            {
                var vendas = await _vendaRepo.GetTodasVendas();

                if (vendas != null)
                {
                    var vendaMapped = _mapper.Map<VendaDto[]>(vendas);
                    
                    return vendaMapped;
                }
                else return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<VendaDto> GetVendaPorId(int id)
        {
            try
            {
                var venda = await _vendaRepo.GetVendaPorId(id);

                if (venda != null)
                {
                    var vendaMapped = _mapper.Map<VendaDto>(venda);

                    return vendaMapped;
                }
                else return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<VendaDto[]> GetVendasPorIdCliente(int id)
        {
            try
            {
                var vendas = await _vendaRepo.GetVendasPorIdCliente(id);

                if (vendas != null)
                {
                    var vendaMapped = _mapper.Map<VendaDto[]>(vendas);

                    return vendaMapped;
                }
                else return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<VendaDto[]> GetVendasPorMatriculaFuncionario(int matricula)
        {
            try
            {
                var vendas = await _vendaRepo.GetVendasPorMatriculaFuncionario(matricula);

                if (vendas != null)
                {
                    var vendaMapped = _mapper.Map<VendaDto[]>(vendas);

                    return vendaMapped;
                }
                else return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AdicionarItemVenda(int vendaId, ItemVendaDto itemVenda)
        {
            try
            {
                var venda = await _vendaRepo.GetVendaPorId(vendaId);

                if (venda != null)
                {
                    var itemVendaMapped = _mapper.Map<ItemVenda>(itemVenda);
                    
                    venda.ItensVenda.Add(itemVendaMapped);
                    //venda.ValorTotal = CalculoVendaService.CalculaValorTotal(venda);
                    _genericoRepo.Update(venda);
                    
                    return await _genericoRepo.SaveChangesAsync() ? true : throw new Exception("Houve algum erro ao realizar a venda.");
                }

                return false;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AtualizaVenda(int vendaId, VendaDto model)
        {
            try
            {
                var venda = await _vendaRepo.GetVendaPorId(vendaId);
                if (venda == null) return false;

                else
                {
                    var id = venda.VendaId;
                    var vendaMapped = _mapper.Map(model, venda);

                    vendaMapped.VendaId = id;
                    
                    
                    _genericoRepo.Update(vendaMapped);

                    if (await _genericoRepo.SaveChangesAsync())
                    {
                        return true;
                    }

                    return false;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
