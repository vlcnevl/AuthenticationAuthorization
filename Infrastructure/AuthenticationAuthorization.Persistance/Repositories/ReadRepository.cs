using AuthenticationAuthorization.Application.Repositories;
using AuthenticationAuthorization.Domain.Entities.Common;
using AuthenticationAuthorization.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace AuthenticationAuthorization.Persistance.Repositories;

    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AuthenticationAuthorizationDbContext _context;

        public ReadRepository(AuthenticationAuthorizationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
            return query;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var query = Table.AsQueryable();
            return await  query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            var query = Table.Where(method);
            return query;
        }
    }
