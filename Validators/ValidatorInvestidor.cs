using FluentValidation;

namespace Uniciv.Api.Models
{
    public class ValidatorInvestidor : AbstractValidator<Investidor>
    {
        public ValidatorInvestidor() 
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("O Nome não pode ficar em branco")
                .MinimumLength(2).WithMessage("Nome muito curto")
                .MaximumLength(50).WithMessage("Nome muito longo");
            RuleFor(x => x.Perfil).NotNull().WithMessage("O Perfil não pode ficar vazio")
                .MinimumLength(5).WithMessage("Perfil muito curto")
                .MaximumLength(100).WithMessage("Nome muito longo");
        }
    }
}
