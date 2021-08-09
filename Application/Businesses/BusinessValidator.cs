using Application.Dtos;
using Domain;
using FluentValidation;

namespace Application.Businesses
{
    public class BusinessValidator : AbstractValidator<BusinessDto>
    {
        public BusinessValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
          //  RuleFor(x => x.MobilePhone).NotEmpty();
          //  RuleFor(x => x.MobilePhoneDesc).NotEmpty();
          //  RuleFor(x => x.State).NotEmpty();
        }
    }
}