using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AtaTennisApp.Controllers.Base
{
    public interface IErrorObject
    {
        string ErrorMessage { get; set; }
        object ErrorData { get; set; }
    }

    public class ErrorObject : IErrorObject
    {
        public string ErrorMessage { get; set; }
        public object ErrorData { get; set; }
    }

    public class ApiError
    {
        public int StatusCode { get; private set; }

        public string StatusDescription { get; private set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; private set; }

        public ApiError(int statusCode, string statusDescription)
        {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

        public ApiError(int statusCode, string statusDescription, string message)
            : this(statusCode, statusDescription)
        {
            Message = message;
        }
    }

    public class InternalServerError : ApiError
    {
        public InternalServerError()
            : base(500, HttpStatusCode.InternalServerError.ToString())
        {
        }


        public InternalServerError(string message)
            : base(500, HttpStatusCode.InternalServerError.ToString(), message)
        {
        }
    }

    public class NotFoundError : ApiError
    {
        public NotFoundError()
            : base(404, HttpStatusCode.NotFound.ToString())
        {
        }


        public NotFoundError(string message)
            : base(404, HttpStatusCode.NotFound.ToString(), message)
        {
        }
    }

    // contex session something like that...
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected ActionResult GetErrorResponse(HttpStatusCode statusCode, string message, object errData)
        {
            return StatusCode((int)statusCode, new ErrorObject
            {
                ErrorMessage = message,
                ErrorData = errData
            });
        }

    }
}
