namespace HeroisAPI.Models
{
    public class Resultado
    {
        public IDictionary<string, string[]>? Mensagem { get; set; }

        public Object[]? Dados { get; set; }
        public Resultado()
        {
            
        }
        public Resultado(IDictionary<string, string[]> mensagem, Object[] dados)
        {
            Mensagem = mensagem;
            Dados = dados;
        }
    }
}
