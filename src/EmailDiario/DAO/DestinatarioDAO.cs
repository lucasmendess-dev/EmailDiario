using EmailDiario.Data;
using EmailDiario.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailDiario.DAO
  
    {
    public class DestinatarioDAO
    {
        private readonly EmailDiarioDbContext _context;

        public DestinatarioDAO(EmailDiarioDbContext context)
        {
            _context = context;
        }
        public async Task<List<Destinatario>> ListarTodosAsync()
        {
            return await _context.Destinatarios
                .AsNoTracking()
                .OrderBy(d => d.Nome)
                .ToListAsync();
        }
    }

}
