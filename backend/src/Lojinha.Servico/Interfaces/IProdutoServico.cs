using Lojinha.Servico.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Servico.Interfaces
{
    public interface IProdutoServico
    {
        public Task<ProdutoDto[]> GetTodosProdutos();
        public Task<ProdutoDto[]> GetProdutosPorNome(string nome);
        public Task<ProdutoDto> GetProdutoPorCodigo(int codigo);
        public Task<bool> CadastrarProduto(ProdutoDto produto);
        public Task<bool> AtualizarProdutoPorCodigo(int codigo, ProdutoDto produto);
        public Task<bool> RemoverProdutoPorCodigo(int codigo);

    }
}
