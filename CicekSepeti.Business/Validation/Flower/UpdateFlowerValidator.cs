using CicekSepeti.DAL.Dto.Flower;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Validation.Flower
{
  public  class UpdateFlowerValidator : AbstractValidator<UpdateFlowerDto>
    {
        public UpdateFlowerValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("CustomerName boş bırakılamaz.").MaximumLength(20).WithMessage("Maksımum 20 karakter giriniz.");
            RuleFor(p => p.Type).NotEmpty().WithMessage("Type boş geçilemez.").MaximumLength(20).WithMessage("Maksımum 20 karakter gırınız.");

        }
    }
}
