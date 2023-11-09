using FluentValidation;
using HeroisAPI.Data;
using HeroisAPI.Models;
using System;

namespace HeroisAPI.Services
{
    public class SuperPoderService
    {
        public AppDbContext _appDbcontext { get; set; }
        private readonly IValidator<SuperPoder> _validator;
        public SuperPoderService(AppDbContext appDbContext, IValidator<SuperPoder> validator)
        {
            _appDbcontext = appDbContext;
            _validator = validator;
        }
        public async Task<Resultado> Cadastrar(SuperPoder superPoder)
        {
            var validacao = await _validator.ValidateAsync(superPoder);
            if (!validacao.IsValid) { return new Resultado(validacao.ToDictionary(), null); }

            _appDbcontext.SuperPoderes.Add(superPoder);
            _appDbcontext.SaveChanges();
            return new Resultado();
        }
        public Resultado buscarTodos()
        {
            return new Resultado(null, _appDbcontext.SuperPoderes.ToArray());
        }
        public async Task<Resultado> Editar(SuperPoder superPoder)
        {
            if (_appDbcontext.SuperPoderes.Any(x => x.Id == superPoder.Id))
            {
                var validacao = await _validator.ValidateAsync(superPoder);
                if (!validacao.IsValid) { return new Resultado(validacao.ToDictionary(), null); }

                _appDbcontext.SuperPoderes.Update(superPoder);
                _appDbcontext.SaveChanges();
                return new Resultado(null, new Object[] { superPoder });
            }
            return new Resultado(
                new Dictionary<string, string[]>()
                {
                    ["erro"] = new string[] { "Super poder nao encontrado." },
                }, null);
        }
        public Resultado Remover(int id)
        {
            Resultado resultado = new Resultado();
            Dictionary<string, string[]> mensagem = new Dictionary<string, string[]>();
            SuperPoder? superPoder = _appDbcontext.SuperPoderes.Find(id);
            if (superPoder != null)
            {
                _appDbcontext.Remove(superPoder);
                _appDbcontext.SaveChanges();
                return new Resultado();
            }
            return new Resultado(
                new Dictionary<string, string[]>()
                {
                    ["erro"] = new string[] { "Falha ao remover super poder." },
                }, null);
        }
    }
}
