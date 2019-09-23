using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtaTennisApp.Controllers.Base
{
    [Route("/errors")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("{code}")]
        public IActionResult Error(HttpStatusCode code)
        {
            //HttpStatusCode parsedCode = code;
            ApiError error = new ApiError(code, code.ToString() + " my message");

            return new ObjectResult(error);
        }
    }
}