using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HeroisAPI.Models
{
    public class SuperPoder
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public ICollection<Heroi> Herois { get; set; }

        public SuperPoder()
        {
            
        }
        public SuperPoder(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
 
}
