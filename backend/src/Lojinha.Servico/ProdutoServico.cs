using AutoMapper;
using Lojinha.Dominio.Models;
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
    public class ProdutoServico : IProdutoServico
    {
        private readonly ICrudGenericoRepositorio _genericoRepo;
        private readonly IProdutoRepositorio _produtoRepo;
        private readonly IMapper _mapper;

        public ProdutoServico(ICrudGenericoRepositorio genericoRepo, IProdutoRepositorio produtoRepo, IMapper mapper)
        {
            _genericoRepo = genericoRepo;
            _produtoRepo = produtoRepo;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarProdutoPorCodigo(int codigo, ProdutoDto produtoNovo)
        {
            try
            {
                var produto = await _produtoRepo.GetProdutoPorCodigo(codigo);

                if (produto == null) return false;

                else 
                { 
                    var produtoCodigo = codigo;
                    var produtoMapped = _mapper.Map(produtoNovo, produto);

                    produtoMapped.Codigo = produtoCodigo;

                    _genericoRepo.Update(produtoMapped);

                    return await _genericoRepo.SaveChangesAsync();
                }

                throw new Exception("Erro ao atualizar produto");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> CadastrarProduto(ProdutoDto produto)
        {
            try
            {
                var produtoMapped = _mapper.Map<Produto>(produto);
                
                _genericoRepo.Add(produtoMapped);
                
                return await _genericoRepo.SaveChangesAsync() ? true : throw new Exception("Houve algum erro ao cadastrar novo Cliente.");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ProdutoDto> GetProdutoPorCodigo(int codigo)
        {
            try
            {
                var produto = await _produtoRepo.GetProdutoPorCodigo(codigo);

                if (produto != null)
                {
                    var produtoMapped = _mapper.Map<ProdutoDto>(produto);

                    return produtoMapped;
                }
                else return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ProdutoDto[]> GetProdutosPorNome(string nome)
        {
            try
            {
                var produtos = await _produtoRepo.GetProdutosPorNome(nome);

                if (produtos != null)
                {
                    var produtoMapped = _mapper.Map<ProdutoDto[]>(produtos);
                    return produtoMapped;
                }
                else return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ProdutoDto[]> GetTodosProdutos()
        {
            try
            {
                var produtos = await _produtoRepo.GetTodosProdutos();

                if (produtos != null)
                {
                    var produtoMapped = _mapper.Map<ProdutoDto[]>(produtos);
                    return produtoMapped;
                }
                else return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> RemoverProdutoPorCodigo(int codigo)
        {
            try
            {
                var produto = await _produtoRepo.GetProdutoPorCodigo(codigo);


                if (produto == null)
                {
                    throw new Exception("Erro ao excluir. Cliente não encontrado.");
                }

                _genericoRepo.Remove(produto);
                return await _genericoRepo.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
