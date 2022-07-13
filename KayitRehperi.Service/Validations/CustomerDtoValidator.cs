using FluentValidation;
using KayitRehperi.Core.DTOs;

namespace KayitRehperi.Service.Validations
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            //RuleFor(x => x.Name).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            //RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            
        }

    }
}
