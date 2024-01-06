using Microsoft.EntityFrameworkCore;
using RepositoryPattern.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.EF.Repositoriess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query=_context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query=query.Include(include);
            return query.SingleOrDefault(match);
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
