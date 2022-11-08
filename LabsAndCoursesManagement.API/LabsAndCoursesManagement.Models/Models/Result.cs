using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsAndCoursesManagement.Models.Models
{
    public class Result
    {
        public string Error { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsFailure { get; private set; }

        public static Result Success()
        {
            return new Result
            {
                IsSuccess = true
            };
        }

        public static Result Failure(string error)
        {
            return new Result
            {
                Error = error,
                IsFailure = true
            };
        }
    }
}
