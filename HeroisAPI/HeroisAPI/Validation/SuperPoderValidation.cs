using FluentValidation;
using HeroisAPI.Data;
using HeroisAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace HeroisAPI.Validation
{
    public class SuperPoderValidation : AbstractValidator<SuperPoder>
    {
        public SuperPoderValidation(AppDbContext appDbContext)
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MustAsync(async (nome, cancelation) =>
            {
                return !appDbContext.SuperPoderes.AnyAsync(x => x.Nome == nome).Result;
            }).WithMessage("ja cadastrado.");
            RuleFor(x => x.Descricao).NotNull().NotEmpty();
        }
    }

}
