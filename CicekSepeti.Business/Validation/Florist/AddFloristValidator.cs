using CicekSepeti.DAL.Dto.Florist;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Validation.Florist
{
  public   class AddFloristValidator : AbstractValidator<AddFloristDto>
    {
        public AddFloristValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("name boş bırakılamaz.").MaximumLength(20).WithMessage("maksımum 20 karakter gırınız.");
            RuleFor(p => p.FloristNumber).NotEmpty().WithMessage("FloristNumber boş bırakılamaz.");

        }
    }
}
