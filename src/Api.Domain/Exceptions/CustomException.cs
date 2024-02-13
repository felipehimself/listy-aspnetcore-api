using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Domain.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; }


        public CustomException() : base() { }

        public CustomException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {

            StatusCode = statusCode;

        }
    }
}