using webapi.Context;

namespace webapi.Repositories
{
    public class RepositoryBase
    {
        protected AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }
    }
}
