using LabsAndCoursesManagement.Models.Helpers;

namespace LabsAndCoursesManagement.BusinessLogic.Base
{
    public interface IBaseService<T, TDto>
        where T : class
        where TDto : class
    {
        Task<Result<T?>> Add(TDto dto);
        Task<Result<T>> Delete(Guid id);
        Task<Result<IEnumerable<T>>> GetAll();
        Task<Result<T>> GetById(Guid id);
        Task<Result<T>> Update(Guid id, TDto dto);
    }
}