using Abc.Core.DataAccess;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.DataAccess.Abstract
{
    //ORM Değişikliği durumu için kullanılır.(EF den  NHibernate geçiş sağlandığında bu interface işe yarar)
    public interface IProductDal:IEntityRepository<Product>
    {
        //List<Product> GetList(); //bunu buraya yazmaya gerek kalmadı zaten IEntity Repository interface ile otomatik olarak metotlar tanımlanıyor.

        //özel metotları burda tanımlıyoruz

        //Product GetProductwitProductName();     gibi



    }
}
