using CicekSepeti.DAL.Dto.FloristCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Validation.FloristCustomer
{
  public  class AddFloristCustomerValidator : AbstractValidator<AddFloristCustomerDto>
    {
        public AddFloristCustomerValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("CustomerId boş bırakılamaz.");
            RuleFor(p => p.FloristId).NotEmpty().WithMessage("FloristId boş bırakılamaz");

        }
    }
}
