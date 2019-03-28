using Abc.Northwind.Business.Absctract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.DataAccess.Concrete.NHibernate;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.Business.Infrastructure;

//manage nugeta ninjecti yüklüyoruz.
namespace Abc.Northwind.Business.DependencyResolvers.Ninject
{
    //DEPENDECY INJECTION YAPILANDIRMASI
    public class BusinessModule :NinjectModule
      {
        public override void Load()
        {

            //AddBllBindings(); //sistemi BLL'e geçirmek için
            AddServiceBindings();//sistemi WCF servise geçirdik







            //-------GENERIC OLMAYAN YONTEM
            //IProductService productService = WcfServiceProxy.CreateChannel();
            //Bind<IProductService>().ToConstant(productService);


        }

        //Business Bindingleri
        private void AddBllBindings()
        {
            //birisi senden constructorda IProductService isterse ona ProductManager i ver.
            Bind<IProductService>().To<ProductManager>();
            //Bind<IProductDal>().To<NhProductDal>();  //ORM'i istersek değiştirebiliyoruz.bağımlılığı ortadan kaldırdık.

            //birisi senden constructorda IProductDal isterse ona EfProductDal i ver.
            Bind<IProductDal>().To<EfProductDal>();

        }

        //service Bindingleri 
        private void AddServiceBindings()
        {
            //--------GENERIC YONTEM
            //olurda biri senden IProductService isterse 
            Bind<IProductService>().ToConstant(WcfServiceProxy<IProductService>.CreateChannel());
            

        }
    }
}
