using Lojinha.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        public Task<Produto[]> GetTodosProdutos();
        public Task<Produto[]> GetProdutosPorNome(string nome);
        public Task<Produto> GetProdutoPorCodigo(int codigo);
        
    }
}
