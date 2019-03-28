using Abc.Northwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;
using System.Linq.Expressions;

namespace Abc.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : IProductDal
    {
        //Nhibernatein ekleme güncelleme silme işlemleri yapılacak
        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
