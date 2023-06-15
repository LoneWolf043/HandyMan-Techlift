using HandyMan_Techlift.Models;
using HandyMan_Techlift.Data;

namespace HandyMan_Techlift.Repositories
{
    public class Categoriesrep : ICategoriesrep
    {
        private readonly HandyManDbContext _context;
        public Categoriesrep(HandyManDbContext context)
        {
            _context = context;
        }
        public int Create(Categories c)
        {
            _context.categories.Add(c);
            return _context.SaveChanges();
        }

        public int Delete(Guid CategoryId)
        {
            _context.categories.Remove(_context.categories.Where(a => a.CategoryId == CategoryId).SingleOrDefault());
            return _context.SaveChanges();
        }

        public IEnumerable<Categories> Details()
        {
            return _context.categories.ToList();
        }

        public int Edit(Categories c)
        {
            _context.categories.Update(c);
            return _context.SaveChanges();
        }
    }
}
