using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;



using System.ServiceModel;//Dll'ide ekledik--> ServiceContract attribute için .WCF için.
namespace Abc.Northwind.Business.Absctract
{

    [ServiceContract]//Servis olarak dışarıya açılması için
    public interface IProductService
    {
        //ProductManagerda bu metotları implemente ediyoruz.

        [OperationContract] //methodları servis olarak sunmak için
        List<Product> GetAll();
        [OperationContract]
        List<Product> GetAllByCategory(int categoryId);
        [OperationContract]
        void Add(Product product);
        [OperationContract]
        void Update(Product product);
        [OperationContract]
        void Delete(Product product);

    }
}
