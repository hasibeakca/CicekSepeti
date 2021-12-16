using CicekSepeti.DAL.Dto.FloristFlower;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Validation.FloristFlower
{
  public  class UpdateFloristFlowerValidator : AbstractValidator<UpdateFloristFlowerDto>
    {
        public UpdateFloristFlowerValidator()
        {
            RuleFor(p => p.FloristId).NotEmpty().WithMessage("FloristId boş bırakılamaz.");
            RuleFor(p => p.FlowerId).NotEmpty().WithMessage("FlowerId boş bırakılamaz.");

        }
    }
}
