using Abc.Northwind.Business.Absctract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {



        /*

            Global.asax'a ninjectin tanımlamasını yapıyoruz vede MVCUI PROJESİNE manage nugettan ninjecti yüklüyoruz
               ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));



         */

        //DEPENDENCY INJECTION 
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public ActionResult Index()
        {

           // IProductService productService = new ProductManager(new EfProductDal()); //dependecy injection yaparak bu yöntemden kurtuluyoruz.
            var products = _productService.GetAll();


            //fluent validation testi için yapıyoruz
            Add();
            return View();
        }

        //fluent validation testi için yapıyoruz
        public void Add()
        {
           _productService.Add(new Product {ProductName="kalem" });
           
        }
    }
}


/*
 webconfige connection string ekliyoruz


      <connectionStrings>
    <add name="NorthwindContext" connectionString="Data Source=.;Initial Catalog=Northwind;Integrated Security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
  </connectionStrings>



    manage nugettan entity framework yüklüyoruz.
     
     */



/*
HATA VE ÇÖÜZÜM
 No Entity Framework provider found for the ADO.NET provider with invariant name 'System.Data.SqlClient'. Make sure the provider is registered in the 'entityFramework' section of the application config file. See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

       manage nugettan entity framework yüklüyoruz ve düzeliyor.
 */


