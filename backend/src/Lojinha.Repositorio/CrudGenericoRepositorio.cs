using Lojinha.Repositorio.Contexto;
using Lojinha.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio
{
    public class CrudGenericoRepositorio : ICrudGenericoRepositorio
    {
        private readonly LojinhaDbContext _contexto;

        public CrudGenericoRepositorio(LojinhaDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Add<T>(T entidade) where T : class
        {
            _contexto.Add(entidade);
        }
        public void Update<T>(T entidade) where T : class
        {
            if (_contexto.ChangeTracker.HasChanges()) 
                _contexto.Update(entidade);
        }

        public void Remove<T>(T entidade) where T : class
        {
            _contexto.Remove(entidade);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }

    }
}
