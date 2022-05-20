using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidation: AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductCode).NotEmpty().WithMessage("Lütfen Ürün Kodunu 00- ile Başlatınız.");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Lütfen Eklemek istediğiniz Parça Adını Yazınız.");
        }
    }
}
