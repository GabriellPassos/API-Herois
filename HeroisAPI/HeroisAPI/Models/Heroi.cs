using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace HeroisAPI.Models
{
    public class Heroi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string NomeHeroi { get; set; }

        [Required]
        public float Altura { get; set; }
        [Required]
        public float Peso { get; set; }
        [AllowNull]
        public DateOnly? Nascimento { get; set; }

        public ICollection<SuperPoder> SuperPoderes { get; set; }
        public Heroi(){}
        public Heroi(string nome, string nomeHeroi, float altura, float peso, DateOnly nascimento)
        {
            Nome = nome;
            NomeHeroi = nomeHeroi;
            Altura = altura;
            Peso = peso;
            Nascimento = nascimento;
        }
    }
}