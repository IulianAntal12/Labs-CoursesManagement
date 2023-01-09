using Finbuckle.MultiTenant;
using LabsAndCoursesManagement.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LabsAndCoursesManagement.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext context;

        protected Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public virtual async Task<T?> Add(T entity)
        {
            CheckDatabaseContextStatus();
            await context.Set<T>().AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> All()
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

            Type entityType = typeof(T);
            MethodInfo? keyMethodInfo = entityType.GetMethod("set_Id", BindingFlags.NonPublic | BindingFlags.Instance);
            if (keyMethodInfo == null)
            {
                return null;
            }
            keyMethodInfo.Invoke(entity, new object[] { key });


            MethodInfo? tenantMethodInfo = entityType.GetMethod("set_Tenant", BindingFlags.Public | BindingFlags.Instance);
            MethodInfo? getMethodInfo = entityType.GetMethod("get_Tenant", BindingFlags.Public | BindingFlags.Instance);
            
            if (tenantMethodInfo == null)
            {
                return null;
            }
            string tenant = (string) getMethodInfo.Invoke(toBeUpdated, new object[] { });
            tenantMethodInfo.Invoke(entity, new object[] { tenant });


            context.Entry(toBeUpdated)
                .CurrentValues
                .SetValues(entity);

            await SaveChanges();
            return entity;
        }
        public virtual void CheckDatabaseContextStatus()
        {
            if (context is null || context.Set<T>() is null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
