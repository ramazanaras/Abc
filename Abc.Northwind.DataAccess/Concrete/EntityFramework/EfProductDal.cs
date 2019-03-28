using Abc.Northwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;
using System.Linq.Expressions;
using Abc.Core;
using Abc.Northwind.DataAccess.Concrete.EntityFramework.Contexts;
using Abc.Core.DataAccess.EntityFramework;

namespace Abc.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
        //Entity framework işlemleri yapılacak

        //Burada aşağıdaki işlemleri her bir tablo için tek tek yapmak yerine EfEntityRepositoryBase generic classında otomatik olarak yapıyoruz.
        //public Product Add(Product entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Product entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Product Get(Expression<Func<Product, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Product> GetList()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public Product Update(Product entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
