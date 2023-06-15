using HandyMan_Techlift.Data;
using HandyMan_Techlift.Models;

namespace HandyMan_Techlift.Repositories
{
    public class Servicesrep : IServicesrep
    {
        private readonly HandyManDbContext _context;
        public Servicesrep(HandyManDbContext context)
        {
            _context = context;
        }
        public int Create(Services s)
        {
            _context.services.Add(s);
            return _context.SaveChanges();
        }

        public int Delete(Guid ServiceId)
        {
            _context.services.Remove(_context.services.Where(a => a.ServiceID == ServiceId).SingleOrDefault());
            return _context.SaveChanges();
        }

        public IEnumerable<Services> Details()
        {
            return _context.services.ToList();
        }

        public int Edit(Services s)
        {
            _context.services.Update(s);
            return _context.SaveChanges();
        }
    }
}
