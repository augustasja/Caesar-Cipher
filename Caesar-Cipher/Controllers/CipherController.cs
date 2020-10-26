using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Caesar_Cipher.Models;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Caesar_Cipher.Controllers
{
    public class CipherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Post method that takes PlainText/Encrypted message and applies caesars cipher
        /// </summary>
        /// <param name="Input"> Plain Text</param>
        /// <param name="Output"> CipherText</param>
        /// <param name="Shift"> Shift value for cipher</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(string Input, string Output, int Shift)
        {
            if (!ModelState.IsValid)
            {
                if (!Enumerable.Range(Int32.MinValue, Int32.MaxValue).Contains(Shift))
                    throw new OverflowException("Shift value is too large");
            }
            if (Input != null)
            {
                CaesarsCipherModel cipher = new CaesarsCipherModel(Input, Shift);
                Output = cipher.Encrypt(Input, Shift);
                cipher.Output = Output;
                ViewData["Plain"] = Input;
                ViewData["CipherI"] = Output;
                ViewBag.shift = Shift;
                return View();
            }
            else if (Output != null)
            {
                CaesarsCipherModel cipher = new CaesarsCipherModel(Output, Shift);
                Input = cipher.Decrypt(Output, Shift);
                cipher.Input = Input;
                ViewData["Cipher"] = Output;
                ViewData["CipherO"] = Input;
                ViewBag.shift = Shift;
                return View();
            }
            else
                return View();
        }
    }
}
