using Abc.Northwind.DataAccess.Concrete.EntityFramework.Mappings;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//DataAccess katmanına manage nugettan entity framework yüklüyoruz.
namespace Abc.Northwind.DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext():base("NorthwindContext")
        {
            //bunu yorum satırına çektim çünkü başta veritabanını otomatik olarak oluşturmak için yoksa böyle bir hata veriyordu.(An unhandled exception of type 'System.Data.Entity.Core.EntityException' occurred in EntityFramework.SqlServer.dll    Additional information: The underlying provider failed on Open.)
            //Database.SetInitializer<NorthwindContext>(null);
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //oluşturduğumuz mappi burda tanımlıyoruz.
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
