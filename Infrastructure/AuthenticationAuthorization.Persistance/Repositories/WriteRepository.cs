using AuthenticationAuthorization.Application.Repositories;
using AuthenticationAuthorization.Domain.Entities.Common;
using AuthenticationAuthorization.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace AuthenticationAuthorization.Persistance.Repositories;
   public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        private readonly AuthenticationAuthorizationDbContext _context;

        public WriteRepository(AuthenticationAuthorizationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
          EntityEntry entityEntry =  await Table.AddAsync(entity);
          return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
           EntityEntry<T> entityEntry =  Table.Remove(entity);
           return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
           T entity = await Table.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));
           return Remove(entity);
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync(); 

        public bool Update(T entity)
        {
           EntityEntry entityEntry=  Table.Update(entity);
           return entityEntry.State == EntityState.Modified;
        }
    }
