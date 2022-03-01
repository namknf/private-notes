namespace PrivateNotes.Entities
{
    using FluentValidation;
    using PrivateNotes.Pages;

    public class RegisterValidator : AbstractValidator<RegistrationModel>
    {
        [System.Obsolete]
        public RegisterValidator(int length)
        {
            RuleFor(p => p.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .EmailAddress();

            RuleFor(p => p.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(8, 76);
        }
    }
}
