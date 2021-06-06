using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Mesaj>
    {
        public MessageValidator()
        {

            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");

            RuleFor(x => x.Subjet).NotEmpty().WithMessage("Konu Alanını Boş Geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Alanını Boş Geçemezsiniz");


            RuleFor(x => x.Subjet).MinimumLength(3).WithMessage("En Az 3 Karakter   ");
            RuleFor(x => x.ReceiverMail).MinimumLength(3).WithMessage("En Az 3 Karakter   ");
            RuleFor(x => x.MessageContent).MaximumLength(100).WithMessage("En Fazla 100 Karakter   ");
        }
    }
}
