namespace LabsAndCoursesManagement.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<T?> Add(T entity);
        public Task<IEnumerable<T>> All();
        public void CheckDatabaseContextStatus();
        public Task Delete(T entity);
        public Task<T?> Get(Guid id);
        public Task SaveChanges();
        public Task<T?> Update(Guid key, T entity);
    }
}