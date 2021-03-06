using Hb_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Hb_Project.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        List<T> Get();
        T? Get(int id);
        bool Update(int id, T entity);
        int Add(T entity);
        bool Delete(int id);
    }
}
