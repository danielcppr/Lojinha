using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio.Interfaces
{
    public interface ICrudGenericoRepositorio
    {
        public void Add<T>(T entidade) where T : class;
        public void Update<T>(T entidade) where T : class;
        public void Remove<T>(T entidade) where T : class;
        public Task<bool> SaveChangesAsync();

    }
}
