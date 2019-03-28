using Abc.Northwind.Business.Absctract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

//web api projesine manage nugettan entity framework yükle
namespace Abc.Northwind.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {

        //dependecy injection
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //http://localhost:49464/api/products ulaşıyoruz
        public List<Product> Get()
        {

            return _productService.GetAll();
        }

    }
}


/*
webconfige connection string ekliyoruz


  <connectionStrings>
<add name="NorthwindContext" connectionString="Data Source=.;Initial Catalog=Northwind;Integrated Security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
</connectionStrings>



manage nugettan entity framework yüklüyoruz.

  manage nugettan  WebApiContrib.IoC.Ninject yüklüyoruz

 */



/*
 * 
 *   *************DEPENDECY INJECTION YAPILANDIRMALARI***************************
 * Hata ve çözümü
 * 
 * Dependecy injection ayarı uygulamadığımız için böyle bir hata verdi.
An error occurred when trying to create a controller of type 'ProductsController'. Make sure that the controller has a parameterless public constructor.


  
    * 
    ÇÖZÜMÜ
      manage nugettan  WebApiContrib.IoC.Ninject yüklüyoruz içinde Ninject ile beraber geliyor yani Ninjectide yüklüyor.dikkat etmemiz gereken nokta tüm projelerde Ninjectin versiyonlarının aynı olmasında dikkat et.eski versiyon varsa güncelle.yani versiyonların hepsi aynı olmalı
      manage nugettan  Ninject.MVC5  yüklüyoruz



    Ninject.Web.Common ve Ninject.Web.Common.Host u 3.3.1 'e güncelliyoruz. yoksa NinjectWebCommon classı oluşmaz.




    NinjectWebCommon CLASSINA AŞAĞIDAKİLER EKLİYORUZ


       //***********************EKLİYORUZ*****************************
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);


       //***********************EKLİYORUZ*****************************
            kernel.Load(new BusinessModule());
 */
