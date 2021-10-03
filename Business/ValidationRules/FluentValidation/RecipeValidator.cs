using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RecipeValidator:AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(r => r.Title).NotEmpty();
        }

    }
}
