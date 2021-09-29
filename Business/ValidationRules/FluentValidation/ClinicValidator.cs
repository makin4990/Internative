using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class ClinicValidator: AbstractValidator<Clinic>
    {
        public ClinicValidator()
        {

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Klinik adı boş bırakılamaz.");
          
        }
    }
}
