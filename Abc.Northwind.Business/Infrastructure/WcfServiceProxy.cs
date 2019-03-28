using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ServiceModel;//referansalara ekledik .Wcf için


//-------------WCF CHANNEL FACTORY YONTEMİ-------------------

namespace Abc.Northwind.Business.Infrastructure
{
    //Client tarafında endpoint oluşturmak için yaptık bu classı
    public static class WcfServiceProxy<T>
    {
        //add service referans diyormuş gibi bu kodlarda aynı işlemi görür

        //Generic halde yaptık
        public static T CreateChannel()
        {
            string address = string.Format("http://localhost:3427/{0}.svc?wsdl", typeof(T).Name.Substring(1));  //WCF ABC'sinin a'sı
            var binding = new BasicHttpBinding();   //WCF ABC'sinin b'sı

            var channel = new ChannelFactory<T>(binding, address);



            return channel.CreateChannel();

            //Business module sınıfında bu şekilde kullanırıız
            //  Bind<IProductService>().ToConstant(WcfServiceProxy<IProductService>.CreateChannel());
        }


        //public static IProductService CreateChannel()
        //{
        //    string address = "http://localhost:3427/ProductService.svc?wsdl";  //WCF ABC'sinin a'sı
        //    var binding = new BasicHttpBinding();   //WCF ABC'sinin b'sı

        //    var channel = new ChannelFactory<IProductService>(binding,address);



        //    return channel.CreateChannel();



        ////Business module sınıfında bu şekilde kullanırıız
        ////IProductService productService = WcfServiceProxy.CreateChannel();
        ////Bind<IProductService>().ToConstant(productService);

        //}



        /*
         yukarıdaki metodu BusinessModule sınıfında aşağıdaki gibi kullanırız

           //generic olmayan yöntem
            //IProductService productService = WcfServiceProxy.CreateChannel();
            //Bind<IProductService>().ToConstant(productService);
         */
    }
}

// http://localhost:3427/ProductService.svc



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
 *birde WCFIISHost projesine sağ tıklayıp Add-->Reference diyoruz ve WCFServiceLibary projesini seçiyoruz.
 * Çünkü WCfIIshost projesi WcfServiceLibraryi tanımalı.İşlemi yaptıktan sonra WcfIISHost projesinde Bin klasörü oluşur yani dll'ler gelir.

 *
 * 
 * 
 * http://localhost:3427/Product.svc
 * http://localhost:3427/Category.svc
 */


/*
WCFIISHOst  --> yayınlayıcı proje (IISde) Add new WebSite diyerek oluşturuyoruz


New Project --WCF Service Application ise hem yayınlayıcı hemde kodların olduğu bir proje şeklidir.Yani hem yayınlayıcıyı hemde kodları tek bir proje toplamak için açılır.

Biz ise kodları ve yayınlayıcıyı ayrı projelerde yapıyoruz.



Servisi yayına çıkarmak için bu iki attribütü eklemek gerekiyor.Daha bitmedi bu servisi yayına çıkarmak için WCFIISHost projesinin webconfigini ayarlıyoruz

WCFIIShost projesinin webconfigini aşağıdaki gibi ayarlıyoruz

<ServiceHostingEnvironmment>
<add Service ......relativeadres=""
kodlarını yazarak servisleri yayına çıkarıyoruz.relativeadres kısmı servisini yayındaki yolu oluyor.

WCFIISHost projesine sağ tıklayıp Add-->Reference diyoruz ve WCFSErviceLibary projesini seçiyoruz.

WCFIISHOst projesini build web site diyoruz.Daha sonra WCFIIShost projesini set as startup project diyoruz.

localhost:200/ProductService.svc dersek servisin çalıştığını görürüz.


WCFIIShost projesini IIS'de yayınlamak için IIS'e gir ordan WCFIIShost projesini seç

WinforUI projesinde sağ tıklayıp add Service referns diyerek aşağıdaki linki yapıştır
localhost:200/StokService.svc 


IISde yayınlamadanda İkinci Yöntem olarak Solutiona tıklayıp multiple projectden WCFIISHost ve Winform projesini seçebilirsin.Eğer IIS'e atmadan test etmek istiyorsan.

    


 */
