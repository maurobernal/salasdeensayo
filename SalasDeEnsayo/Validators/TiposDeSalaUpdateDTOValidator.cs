using FluentValidation;
using SalasDeEnsayo.DTOs;

namespace SalasDeEnsayo.Validators;

public class TiposDeSalaUpdateDTOValidator : AbstractValidator<TiposDeSalaUpdateDTO>
{
    public TiposDeSalaUpdateDTOValidator()
    {
        // debe contener la palabra es
        RuleFor(r => r.descripcion)
            .MinimumLength(3)
            .MaximumLength(100)
            .NotEmpty()
            .NotNull()
            .Must(s => s.Contains("Es")).WithMessage("No contiene la palabra es")
            ;

    }


}
