using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product> //VM için validasyon işlemi yapıyoruz bunu fluentvalidation dan gelmesi için abstract tan implement ediyoruz
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Ürün adı boş geçilemez").MaximumLength(150).MinimumLength(5).WithMessage("Ürün adı 5-150 karakter arasında olmalıdır");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez").Must(x => x > 0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır");
            RuleFor(x => x.Stock).NotEmpty().NotNull().WithMessage("Ürün stok boş geçilemez").Must(x => x > 0).WithMessage("Ürün stok 0 dan büyük olmalıdır");
        }
    }
}