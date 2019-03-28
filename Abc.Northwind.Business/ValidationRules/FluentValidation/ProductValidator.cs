using Abc.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//manage nugettan fluent validaton yükle
namespace Abc.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Product name should start with A");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
