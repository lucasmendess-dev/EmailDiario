using EmailDiario.Data;

namespace EmailDiario.DAO
  
    {
    public class DestinatarioDAO
    {
        private readonly EmailDiarioDbContext _context;

        public DestinatarioDAO(EmailDiarioDbContext context)
        {
            _context = context;
        }
    }
}
