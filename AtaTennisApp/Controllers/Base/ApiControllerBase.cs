using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AtaTennisApp.Controllers.Base
{
    public class ApiError
    {
        public HttpStatusCode StatusCode { get; private set; }

        public string StatusDescription { get; private set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; private set; }

        public ApiError(HttpStatusCode statusCode, string statusDescription)
        {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

        public ApiError(HttpStatusCode statusCode, string statusDescription, string message)
            : this(statusCode, statusDescription)
        {
            Message = message;
        }
    }

    public class InternalServerError : ApiError
    {
        public InternalServerError()
            : base(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString())
        {
        }


        public InternalServerError(string message)
            : base(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), message)
        {
        }
    }

    public class NotFoundError : ApiError
    {
        public NotFoundError()
            : base(HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString())
        {
        }


        public NotFoundError(string message)
            : base(HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString(), message)
        {
        }
    }

    // contex session something like that...
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected ActionResult GetErrorResponse(HttpStatusCode statusCode, string message)
        {
            return GetErrorResponse(statusCode, null, message);
        }
        protected ActionResult GetErrorResponse(HttpStatusCode statusCode, string statusDescription, string message)
        {
            return new ObjectResult(new ApiError(statusCode, statusDescription, message));
        }

    }
}
