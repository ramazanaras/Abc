using Abc.Northwind.Business.Absctract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KurumsalDB;Integrated Security=True;MultipleActiveResultSets=True");
            //con.Open();



            //return;
            //ilerde dependecy ijection uygulanabilir.
            IProductService productService = new ProductManager(new EfProductDal());

            //veritabanının oluşması için bunu yapıyoruz.
            var testveriler = productService.GetAll();
        }
    }
}

/*
 appconfig'e connection string ekledik


      <connectionStrings>
    <add name="NorthwindContext" connectionString="Data Source=.;Initial Catalog=Northwind;Integrated Security=true" providerName="System.Data.SqlClient"/>
  </connectionStrings>
     
     
     
     */


/*
 HATA VE ÇÖZÜMÜ


Additional information: No Entity Framework provider found for the ADO.NET provider with invariant name 'System.Data.SqlClient'. Make sure the provider is registered in the 'entityFramework' section of the application config file. See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.


    console uı projesine manage nugettan entity framework yükle düzelir.



 */



/*
 HATA VE ÇÖZÜMÜ



 public class NorthwindContext : DbContext
{
    public NorthwindContext():base("NorthwindContext")
    {
        //bunu yorum satırına çektim çünkü başta veritabanını otomatik olarak oluşturmak için yoksa böyle bir hata veriyordu.(An unhandled exception of type 'System.Data.Entity.Core.EntityException' occurred in EntityFramework.SqlServer.dll    Additional information: The underlying provider failed on Open.)
        //Database.SetInitializer<NorthwindContext>(null); //veritanının otomatik oluşmasını englliyor.
    }

 */
