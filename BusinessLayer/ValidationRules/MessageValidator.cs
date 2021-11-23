using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("You cannot leave the reciver name blank.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("You cannot leave the subject blank.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("You cannot leave the message blank.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Please enter at least 3 characters.");
           // RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Email address cannot be empty");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Please don't enter more than 100 characters.");
        }
    }
}
