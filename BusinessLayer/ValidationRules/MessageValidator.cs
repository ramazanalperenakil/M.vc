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
            RuleFor(x => x.Subjet).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini boş Geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Alanını Boş Geçemezsiniz");
            RuleFor(x => x.Subjet).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter  Giriniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli Bir Eposta Adresi Giriniz.").When(x => !string.IsNullOrEmpty(x.ReceiverMail));
            RuleFor(x => x.Subjet).MaximumLength(20).WithMessage("Lütfen 100 Karakterden Fazla Değer Girişi Yapmayın");

        }
    }
}
