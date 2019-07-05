using Microsoft.AspNetCore.Mvc;
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

    // contex session something like that...
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
