using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Writer name cannot be blank");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Writer surname can not be blank");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Section about writer cannot be blank");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Must contain at least one letter 'a' in the About section");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Section writer title cannot be blank");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Please enter at least 2 characters.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Please don't enter more than 50 characters.");
        }
    }
}
