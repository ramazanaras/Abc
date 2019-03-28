//using Abc.Core.Aspects.PostsSharp.ValidationAspects;
using Abc.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Abc.Northwind.Business.Absctract;
using Abc.Northwind.Business.ValidationRules.FluentValidation;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            //DEpendecy injection
            //  //böyle yaparak EF den  Nhibernate geçiş sağlanabilir.Çünkü bağımlılığı ortadan kaldırdık. 
            _productDal = productDal;
        }

        public List<Product> GetProducts()
        {
            /*
            //doğru bir kullanım olmadı çünkü bu katmandaki bir class gitti başk bir katmandaki classı new()'ledi. SOLID'İN D'sine göre üst katman alt katmanı new'leyemez.Bunun için Dependency injection kullanıp bağımlılıkları azaltcaz.
            EfProductDal productDal = new EfProductDal();
            return productDal.GetList();
            */

            //böyle yaparak EF den  Nhibernate geçiş sağlanabilir.Çünkü bağımlılığı ortadan kaldırdık. 
            return _productDal.GetList();

        }

        //PostSharp ile attribute bazında validation işlemi gerçekleştirebiliriz.
  //      [FluentValidationAspect(typeof(ProductValidator))]
        public void Add(Product product)
        {
            //validation işlemi yapıyoruz.
            //AOP (Aspect oriented programming tekniği)
             ValidationTool.FluentValidate(new ProductValidator(), product); //böyle yapmak yerine PostSharp ile attribute bazında yaparak daha temiz bir kod uygulayabiliriz.AOP'nin temellerinden biri.öncelikle Core projesine ve Business projesine manage nugettan PostSharp yükle.
            //yukarda FluentValidationAspect attribute vasıtasıyla daha temiz bir kod uygulamış oluyoruz PostSharp ile



            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
           return  _productDal.GetList();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _productDal.GetList(x => x.CategoryId == categoryId);
        }

       

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
