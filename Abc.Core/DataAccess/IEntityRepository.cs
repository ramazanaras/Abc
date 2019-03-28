using Abc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //IProductDal veya ICategoryDal 'da bunları tekrar tekrar tanımlamamak için böyle bir interface yaptık

        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

    }
}
