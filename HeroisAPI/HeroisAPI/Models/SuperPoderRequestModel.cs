using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HeroisAPI.Models
{
    public class SuperPoderRequestModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Heroi { get; set; }

    }
 
}
