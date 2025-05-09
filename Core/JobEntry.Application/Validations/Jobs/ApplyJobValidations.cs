using FluentValidation;
using JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;

namespace JobEntry.Application.Validations.Jobs;

public class ApplyJobValidations: AbstractValidator<CreateApplyJobCommand>
{
    public ApplyJobValidations()
    {
        RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Isim Soyisim Zorunludur");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email Adresinizi Giriniz");
        RuleFor(x=>x.CvFile).NotEmpty().WithMessage("Cv Ekleyiniz");
    }
}