using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Core.Interfaces.Data
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
