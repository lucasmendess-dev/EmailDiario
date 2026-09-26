namespace EmailDiario.Models
{
    public class VinculoEnvio
    {
        public int Id { get; set; }
        public int DestinatarioId { get; set; }
        public int MensagemId { get; set; }
        public Destinatario Destinatario { get; set; } = null!;
        public Mensagem Mensagem { get; set; } = null!;
        public bool Ativo { get; set; } = true;
    }
}
