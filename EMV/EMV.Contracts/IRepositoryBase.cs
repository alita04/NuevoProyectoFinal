using EMV.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.Contracts
{
    public interface IRepositoryBase<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
