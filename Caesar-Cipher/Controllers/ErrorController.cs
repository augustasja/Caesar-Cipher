using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Caesar_Cipher.Controllers
{
    /// <summary>
    /// Custom Error Controller That Redirects To Error Page
    /// </summary>
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        [Route("CipherError")]
        public IActionResult cipherError()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;

            return View("CipherError");
        }
    }
}
