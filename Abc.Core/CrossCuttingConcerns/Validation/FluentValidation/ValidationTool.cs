using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Crosscutting concern uygulamayı dikene keser.Caching,validation(client validation,server validation),authorization,logging gibi işlemler yapılır.


//manage nugettan fluentvalidaton yükle
namespace Abc.Core.CrossCuttingConcerns.Validation.FluentValidation
{
  public static  class ValidationTool
    {
        public static void FluentValidate(IValidator validator,object entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }


        }
    }
}
