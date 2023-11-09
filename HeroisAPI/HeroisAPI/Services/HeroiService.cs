using FluentValidation;
using HeroisAPI.Data;
using HeroisAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroisAPI.Services
{
    public class HeroiService
    {
        public AppDbContext _appDbcontext { get; set; }
        private readonly IValidator<Heroi> _validator;
        public HeroiService(AppDbContext appDbContext, IValidator<Heroi> validator)
        {
            _appDbcontext = appDbContext;
            _validator = validator;
        }
        public async Task<Resultado> Cadastrar(Heroi heroi)
        {
            List<SuperPoder> listaSuperPoderes = new List<SuperPoder>();
            foreach (var spo in heroi.SuperPoderes)
            {
                SuperPoder poderCadastrado = _appDbcontext.SuperPoderes.FirstOrDefaultAsync(x => x.Id == spo.Id).Result;
                if (poderCadastrado != null)
                {
                    listaSuperPoderes.Add(poderCadastrado);
                }
            }
            if (listaSuperPoderes.Any())
            {
                heroi.SuperPoderes = listaSuperPoderes;
                var validacao = await _validator.ValidateAsync(heroi);

                if (!validacao.IsValid) { return new Resultado(validacao.ToDictionary(), null); }

                _appDbcontext.Herois.Add(heroi);
                _appDbcontext.SaveChanges();

                return new Resultado();
            }
            return new Resultado(
                new Dictionary<string, string[]>()
                {
                    ["erro"] = new string[] { "Falha ao cadastrar heroi." },
                }, null);
        }
        public Resultado buscarTodos()
        {
            return new Resultado(null, _appDbcontext.Herois.Include(x => x.SuperPoderes).ToArray());
        }
        public Resultado buscarPorId(int id)
        {
            Heroi? heroi = _appDbcontext.Herois.Find(id);
            if (heroi != null)
            {
                return new Resultado(null, new object[] { heroi });
            }
            return new Resultado(
                new Dictionary<string, string[]>()
                {
                    ["erro"] = new string[] { "Falha ao buscar heroi." },
                }, null);
        }
        public async Task<Resultado> Editar(Heroi heroi)
        {
            List<SuperPoder> listaSuperPoderes = new List<SuperPoder>();
            foreach (var spo in heroi.SuperPoderes)
            {
                SuperPoder poderCadastrado = _appDbcontext.SuperPoderes.FirstOrDefaultAsync(x => x.Id == spo.Id).Result;
                if (poderCadastrado != null)
                {
                    listaSuperPoderes.Add(poderCadastrado);
                }
            }
            if (listaSuperPoderes.Any())
            {
                var validacao = await _validator.ValidateAsync(heroi);

                if (!validacao.IsValid) { return new Resultado(validacao.ToDictionary(), null); }

                var heroiAntigo = _appDbcontext.Herois.Include(x => x.SuperPoderes).First(c => c.Id == heroi.Id);
                heroiAntigo.SuperPoderes.Clear();
                heroiAntigo.Nome = heroi.Nome;
                heroiAntigo.NomeHeroi = heroi.NomeHeroi;
                heroiAntigo.SuperPoderes = listaSuperPoderes;
                heroiAntigo.Altura = heroi.Altura;
                heroiAntigo.Peso = heroi.Peso;
                heroiAntigo.Nascimento = heroi.Nascimento;
                _appDbcontext.SaveChanges();

                return new Resultado();
            }
            return new Resultado(
                new Dictionary<string, string[]>()
                {
                    ["erro"] = new string[] { "Falha ao cadastrar heroi." },
                }, null);
            /*List<SuperPoder> listaSuperPoderes = new List<SuperPoder>();
            foreach (var spo in heroi.SuperPoderes)
            {
                SuperPoder poderCadastrado = _appDbcontext.SuperPoderes.FirstOrDefaultAsync(x => x.Id == spo.Id).Result;
                if (poderCadastrado != null)
                {
                    listaSuperPoderes.Add(poderCadastrado);
                }
            }
            if (listaSuperPoderes.Any())
            {
                heroi.SuperPoderes = listaSuperPoderes;
                var validacao = await _validator.ValidateAsync(heroi);

                if (!validacao.IsValid) { return new Resultado(validacao.ToDictionary(), null); }

                _appDbcontext.Herois.Update(heroi);
                _appDbcontext.SaveChanges();

                return new Resultado();
            }
            return new Resultado(
                new Dictionary<string, string[]>()
                {
                    ["erro"] = new string[] { "Falha ao cadastrar heroi." },
                }, null);*/
        }
        public Resultado Remover(int id)
        {
            Resultado resultado = new Resultado();
            Dictionary<string, string[]> mensagem = new Dictionary<string, string[]>();
            Heroi? heroi = _appDbcontext.Herois.Find(id);
            if (heroi != null)
            {
                _appDbcontext.Remove(heroi);
                _appDbcontext.SaveChanges();
                return new Resultado();
            }
            return new Resultado(
                new Dictionary<string, string[]>()
                {
                    ["erro"] = new string[] { "Falha ao remover heroi." },
                }, null);
        }
    }
}
