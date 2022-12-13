using AutoMapper;
using FluentValidation;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Helpers;
using System.Net;

namespace LabsAndCoursesManagement.BusinessLogic.Base
{
    public class BaseService<T, TDto> : IBaseService<T, TDto> where T : class
        where TDto : class
    {
        protected readonly IMapper mapper;
        protected readonly IRepository<T> repository;
        protected readonly IValidator<T> validator;

        public BaseService(IRepository<T> repository, IValidator<T?> validator)
        {
            mapper = new AutoMapperBuilder().Build();
            this.repository = repository;
            this.validator = validator;
        }
        public async Task<Result<T?>> Add(TDto dto)
        {
            T entity = mapper.Map<T>(dto);
            var validationResult = await validator.ValidateAsync(entity);
            if (!validationResult.IsValid) 
            {
                return Result<T?>.Failure(HttpStatusCode.UnprocessableEntity, validationResult.Errors[0].ErrorMessage);
            }

            var result = await repository.Add(entity);
            if (result == null)
            {
                return Result<T?>.Failure(HttpStatusCode.BadRequest, "Something went wrong while adding object to database");
            }

            await repository.SaveChanges();
            return Result<T?>.Success(result);
        }

        public async Task<Result<T>> Delete(Guid id)
        {
            var entity = await repository.Get(id);
            if (entity == null)
            {
                return Result<T>.Failure(HttpStatusCode.NotFound, "Cannot find entity to be deleted");
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
                return Result<T>.Failure(HttpStatusCode.NotFound, "Cannot find entity specified by id");
            }
            return Result<T>.Success(entity);
        }

        public async Task<Result<T>> Update(Guid id, TDto dto)
        {
            var entity = mapper.Map<T>(dto);
            var validationResult = await validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                return Result<T>.Failure(HttpStatusCode.UnprocessableEntity, validationResult.Errors[0].ErrorMessage);
            }

            var response = await repository.Update(id, entity);
            if (response == null)
            {
                return Result<T>.Failure(HttpStatusCode.NotFound, "Cannot find entity specified by id");
            }
            return Result<T>.Success(response);
        }
    }
}
