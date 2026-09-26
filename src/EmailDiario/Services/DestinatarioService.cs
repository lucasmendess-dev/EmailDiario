using EmailDiario.DAO;
using EmailDiario.Models;


namespace EmailDiario.Services
{
    public class DestinatarioService
    {
        private readonly DestinatarioDAO _destinatarioDAO;

        public DestinatarioService(DestinatarioDAO destinatarioDAO)
        {
            _destinatarioDAO = destinatarioDAO;
        }

        public async Task<List<Destinatario>> ListarTodosAsync()
        {
            return await _destinatarioDAO.ListarTodosAsync();
        }
    }
}