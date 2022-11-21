using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Base
{
    public class BaseService<T, TDto> : IBaseService<T, TDto> where T : class
        where TDto : class
    {
        private const string NOT_FOUND = "Object not found";
        protected readonly IMapper mapper;
        protected readonly IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.mapper = new AutoMapperBuilder().Build();
            this.repository = repository;
        }
        public async Task<Result<T>> Add(TDto dto)
        {
            T entity = mapper.Map<T>(dto);
            var result = await repository.Add(entity);
            await repository.SaveChanges();
            return Result<T>.Success(result);
        }

        public async Task<Result<T>> Delete(Guid id)
        {
            var entity = await repository.Get(id);
            if (entity == null)
            {
                return Result<T>.Failure(NOT_FOUND);
            }
            await repository.Delete(entity);
            return Result<T>.SuccessNoEntity();
        }

        public async Task<Result<IEnumerable<T>>> GetAll()
        {
            var data = await repository.All();
            return Result<IEnumerable<T>>.Success(data);
        }

        public async Task<Result<T>> GetById(Guid id)
        {
            var entity = await repository.Get(id);
            if (entity == null)
            {
                return Result<T>.Failure(NOT_FOUND);
            }
            return Result<T>.Success(entity);
        }

        public async Task<Result<T>> Update(Guid id, TDto dto)
        {
            var entity = mapper.Map<T>(dto);
            var response = await repository.Update(id, entity);
            if (response == null)
            {
                return Result<T>.Failure("Entity not found");
            }
            return Result<T>.Success(response);
        }

        public Task<Result<T>> Validate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
