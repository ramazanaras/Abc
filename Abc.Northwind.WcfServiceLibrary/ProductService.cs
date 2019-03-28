using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.Business.Absctract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.WcfServiceLibrary
{
    //Wcf Servisi olarak kullanacağımız classlar
    public class ProductService : IProductService
    {

        //Kural:Soa standartlarında bir servisin constructoru olamaz

        //BLL katmanındaki sınıfı kullanıyoruz
        //Instance Provider ile ezilecek
        private ProductManager _productManager = new ProductManager(new EfProductDal());  //IProductDal 'dan implemente edilmiş bir sınıf vermeliyiz.Hangi teknolojiyle çalışacağımızı belirttik.Entity framework ile çalıştığımız için bunu verdik.
        public List<Product> GetAll()
        {
            return _productManager.GetAll();
        }
        public Product Get(int productId)
        {
            return _productManager.GetAll().FirstOrDefault(x=>x.ProductId==productId);
        }

        public void Add(Product product)
        {
            _productManager.Add(product);
        }
        
        public void Update(Product product)
        {
            _productManager.Update(product);
        }

        public void Delete(Product product)
        {
            _productManager.Delete(product);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}


/*
 servisleri yayına çıkarmak için aşağıdakileri WCFIISHost katmanının webconfigine ekledik
 * 
 <!--**************************ekledik****************************-->
    <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true">
      <serviceActivations>

        <add service="Abc.Northwind.WcfServiceLibrary.ProductService" relativeAddress="ProductService.svc"/>
       
      </serviceActivations>
    </serviceHostingEnvironment>
<!--*************************************-->
 
 * birde WCFIISHost katmanının webconfigine connection string ekledik
 *
 *   <!--ekledik-->
  <connectionStrings>
    <add name="NorthwindContext" connectionString="Data Source=.;Initial Catalog=Northwind;Integrated Security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient"/>
  </connectionStrings>
 * 
 * 
 * 
 * 
 * http://localhost:3427/Product.svc
 * http://localhost:3427/Category.svc
 */
