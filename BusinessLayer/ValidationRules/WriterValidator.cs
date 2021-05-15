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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Alanını Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbaut).NotEmpty().WithMessage("Yazar Hakkında Alanını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("En Az 2 Karakter   ");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("En Fazla 50 Karakter   ");
        }
    }
}
