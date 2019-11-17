using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AtaTennisApp.Controllers.Base
{
    // Using exception middlware instead on errors controller because I can log exception 
    // Here I canout capture exception because I dont from which context
    [Route("/errors")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        //public ILogger _logger { get; set; }
        //public ErrorsController(ILogger logger)
        //{
        //    _logger = logger;
        //}

        [Route("{code}")]
        public IActionResult Error(HttpStatusCode code)
        {
            //HttpStatusCode parsedCode = code;
            ApiError error = new ApiError(code, code.ToString() + " my message");

            return new ObjectResult(error);
        }
    }
}