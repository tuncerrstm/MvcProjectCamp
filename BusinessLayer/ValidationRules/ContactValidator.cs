using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Email address cannot be left blank!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("You cannot leave the subject name blank.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("You cannot skip the username");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Please enter at least 3 characters.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Please enter at least 3 characters.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Please don't enter more than 50 characters.");
        }
    }
}
