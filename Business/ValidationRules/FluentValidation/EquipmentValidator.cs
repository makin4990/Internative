using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class EquipmentValidator : AbstractValidator<Equipment>
    {
        public EquipmentValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Ekipman Adı boş bir değer alamaz");
            RuleFor(a => a.Quantity)
                .GreaterThan(0)
                .NotEmpty()
                .WithMessage("Adet 1'den az bir değer alamaz ya da boş bırakılamaz.");
            RuleFor(a => a.UnitPrice)
                .GreaterThanOrEqualTo(0.001)
                .WithMessage("Fiyat 0.001'den daha küçük bir değer alamaz.");
            RuleFor(a => a.UsageRate)
                .InclusiveBetween(0.0, 100)
                .WithMessage("Kullanım Oranı 0 ile 100 arasında bir değer alabilir");

        }
    }
}
