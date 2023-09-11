using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public partial interface IAccountingRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null);
        TEntity GetById(object id);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(object id);
        bool Add(TEntity entity);
    }
}
