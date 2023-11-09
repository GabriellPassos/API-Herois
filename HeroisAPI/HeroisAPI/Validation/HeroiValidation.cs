using FluentValidation;
using HeroisAPI.Data;
using HeroisAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace HeroisAPI.Validation
{
    public class HeroiValidation : AbstractValidator<Heroi>
    {
        public HeroiValidation(AppDbContext appDbContext)
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty();
            RuleFor(x => x.NomeHeroi).NotNull().NotEmpty().MustAsync(async (nomeHeroi, cancelation) =>
            {
                return !appDbContext.Herois.AnyAsync(x => x.NomeHeroi == nomeHeroi).Result;
            }).WithMessage("Ja cadastrado.");
            RuleFor(x => x.SuperPoderes).NotNull().NotEmpty();
            RuleFor(x => x.Altura).NotNull().NotEmpty();
            RuleFor(x => x.Peso).NotNull().NotEmpty();
        }
    }

}
