using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Hb_Project.Domain.Repositories
{
    public interface IBaseRepository<IBaseEntity>
    {
        List<IBaseEntity> Get();
        IBaseEntity? Get(long id);
        bool Update(IBaseEntity entity);
        bool Add(IBaseEntity entity);
        bool Delete(long id);
    }
}
