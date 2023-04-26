using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Common
{
    public class Common<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }

        public static Common<T> SuccessResponse(T data)
        {
            return new Common<T> { Success = true, Data = data };
        }

        public static Common<T> ErrorResponse(string errorMessage)
        {
            return new Common<T> { Success = false, Message = errorMessage };
        }
    }
}
