using LabsAndCoursesManagement.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace LabsAndCoursesManagement.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext context;

        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            CheckDatabaseContextStatus();
            await context.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> All()
        {
            CheckDatabaseContextStatus();
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task Delete(T entity)
        {
            CheckDatabaseContextStatus();
            context.Set<T>().Remove(entity);
            await SaveChanges();
        }


        public virtual async Task<T?> Get(Guid id)
        {
            CheckDatabaseContextStatus();
            return await context.FindAsync<T>(id);
        }

        public virtual async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public virtual async Task<T?> Update(Guid key, T entity)
        {
            CheckDatabaseContextStatus();
            var toBeUpdated = await context.Set<T>()
                                           .FindAsync(key);
            if (toBeUpdated == null)
            {
                return null;
            }
            context.Entry(toBeUpdated)
                .CurrentValues
                .SetValues(entity);

            await SaveChanges();
            return toBeUpdated;
        }
        public virtual void CheckDatabaseContextStatus()
        {
            if (context is null || context.Set<T>() is null)
            {
                throw new ArgumentNullException("Null database");
            }
        }
    }
}
