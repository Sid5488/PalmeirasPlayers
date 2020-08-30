using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalmeirasPlayers.Controllers
{
    [ApiController]
    [Route("/error")]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error() => Problem();
    }
}
