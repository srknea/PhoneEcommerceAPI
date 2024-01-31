using FluentValidation;
using PhoneEcommerce.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Service.Validations
{
    public class BrandDtoValidator : AbstractValidator<BrandDto>
    {
        public BrandDtoValidator()
        {
            RuleFor(x => x.BrandName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(200).WithMessage("{PropertyName} can not be longer than 200 characters");
        }
    }
}
