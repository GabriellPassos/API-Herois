using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace HeroisAPI.Models
{
    public class HeroiRequestModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public DateTime? Nascimento { get; set; }
        public string[] SuperPoderes { get; set; }
    }
}