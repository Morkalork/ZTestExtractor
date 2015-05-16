using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Interfaces;

namespace ZTestExtractor.Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
