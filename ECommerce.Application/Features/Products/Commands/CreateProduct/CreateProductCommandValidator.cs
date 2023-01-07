using ECommerce.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürünün Adını boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(1)
                    .WithMessage("Lütfen Ürün Adını 1 ile 150 arasında karakter giriniz");

            RuleFor(p=>p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Stok Adetini boş geçmeyiniz")
                .MaximumLength(80)
                .MinimumLength(1)
                    .WithMessage("Lütfen Ürün Adını 1 ile 80 arasında karakter giriniz");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürünün Fiyatını boş geçmeyiniz")
                .Must(s => s >= 0)
                    .WithMessage("Stok bilgisi negatif değer olamaz");

        }
    }
}
