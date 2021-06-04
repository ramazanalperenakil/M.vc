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
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanını Boş Geçemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Alanını Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("adınızı  Boş Geçemezsiniz");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 Karakter   ");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En Az 3 Karakter   ");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En Fazla 50 Karakter   ");
        }
    }
}
