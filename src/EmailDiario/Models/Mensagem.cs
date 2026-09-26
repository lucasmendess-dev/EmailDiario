namespace EmailDiario.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Assunto { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}
