namespace LabsAndCoursesManagement.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<IEnumerable<T>> All();
        void CheckDatabaseContextStatus();
        Task Delete(T entity);
        Task<T?> Get(Guid id);
        Task SaveChanges();
        Task<T?> Update(Guid key, T entity);
    }
}