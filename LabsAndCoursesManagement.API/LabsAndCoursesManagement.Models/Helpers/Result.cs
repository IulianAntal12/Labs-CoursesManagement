using System.Net;

namespace LabsAndCoursesManagement.Models.Helpers
{
    public class Result<TEntity>
    {
        public TEntity Entity { get; set; }

        public HttpStatusCode StatusCode { get; private set; }

        public string Error { get; private set; }

        public bool IsSuccess { get; private set; }

        public bool IsFailure { get; private set; }

        public static Result<TEntity> Success(TEntity entity)
        {
            return new Result<TEntity>
            {
                Entity = entity,
                IsSuccess = true
            };
        }

        public static Result<TEntity> SuccessNoEntity()
        {
            return new Result<TEntity>
            {
                IsSuccess = true
            };
        }

        public static Result<TEntity> Failure(HttpStatusCode statusCode, string error)
        {
            return new Result<TEntity>
            {
                Error = error,
                StatusCode = statusCode,
                IsFailure = true
            };
        }
    }
}
