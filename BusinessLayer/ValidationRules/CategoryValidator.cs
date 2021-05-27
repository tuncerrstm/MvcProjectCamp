using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("You cannot leave the category name blank.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("You cannot skip the explanation.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Please enter at least 3 characters.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Please don't enter more than 20 characters.");
        }
    }
}
