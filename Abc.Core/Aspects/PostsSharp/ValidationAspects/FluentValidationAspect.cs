using Abc.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
//using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Core.Aspects.PostsSharp.ValidationAspects
{
    //[Serializable]
    //public class FluentValidationAspect : OnMethodBoundaryAspect
    //{
    //    Type _validatorType;

    //    public FluentValidationAspect(Type validatorType) //typeof(ProductValidator) gelicek
    //    {
    //        _validatorType = validatorType;
    //    }
    //    public override void OnEntry(MethodExecutionArgs args)
    //    {
    //        //Activator.CreateInstance metodu tipi belli olmayan tiplerin tipini öğrenmeye yarar :)
    //        var validator = (IValidator)Activator.CreateInstance(_validatorType); //burda gelen tipi new 'liyoruz. yani ProductValidator validator=new ProductValidator(); gibi 
    //        var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //ProductValidator generic  base classının ilk parametresini aldık .yani ProductValidator : AbstractValidator<Product> burdaki Product classına eriştik.
    //        var entities = args.Arguments.Where(t => t.GetType() == entityType); //args dediğimiz şey bu aspect attributeünün bağlı oldu Add() metodunun parametreleri anlamına gelir.yani public void Add(Product product) burdaki product nesnesine karşlık gelir.

    //        foreach (var entity in entities)
    //        {
    //            ValidationTool.FluentValidate(validator, entity);
    //        }
    //    }
    //}
}
