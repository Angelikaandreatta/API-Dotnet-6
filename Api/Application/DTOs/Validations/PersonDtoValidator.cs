using FluentValidation;

namespace Application.DTOs.Validations
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {

        public PersonDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull()
               .WithMessage("Inform your name");

            RuleFor(x => x.Document)
               .NotEmpty()
               .NotNull()
               .WithMessage("Inform your document");

            RuleFor(x => x.Phone)
              .NotEmpty()
              .NotNull()
              .WithMessage("Inform your phone");
        }
    }
}
