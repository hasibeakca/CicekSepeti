using CicekSepeti.DAL.Dto.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Validation.Customer
{
  public  class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(p=> p.CustomerNo).NotEmpty().WithMessage("CustomerNo boş bırakılamaz.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name boş bırakılamaz.")
                .MaximumLength(20).WithMessage("Maksımum 20 karakter giriniz.");
        }
    }
}
