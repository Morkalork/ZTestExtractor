using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Interfaces;

namespace ZTestExtractor.Data.Entities
{
    public class Entity : IEntity
    {
        public virtual int Id { get; set; }
    }
}
