namespace PrivateNotes.Entities
{
    using FluentValidation;
    using PrivateNotes.Pages;

    public class RegisterValidator : AbstractValidator<RegistrationModel>
    {
        public RegisterValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(p => p.Password)
                .NotEmpty()
                .Length(8, 76);
        }
    }
}
