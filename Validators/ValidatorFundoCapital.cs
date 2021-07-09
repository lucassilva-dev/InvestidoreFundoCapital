using FluentValidation;

namespace Uniciv.Api.Models
{
    public class ValidatorFundoCapital : AbstractValidator<FundoCapital>
    {
        public ValidatorFundoCapital()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("O Nome não pode ficar em branco")
                .MinimumLength(2).WithMessage("Nome muito curto")
                .MaximumLength(50).WithMessage("Nome muito longo");
            RuleFor(x => x.ValorNecessario).NotNull().WithMessage("O Valor necessário é obrigatório");
            RuleFor(x => x.ValorAtual).NotNull().WithMessage("O Valor atual é obrigatório");
            RuleFor(x => x.ValorNecessario).GreaterThan(x => x.ValorAtual).WithMessage("O Valor Necessário não pode ser menor que o atual.");
        }
    }
}
