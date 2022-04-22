using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PayYourLight
{
    [Route("/[controller]")]
    [ApiController]
    public class style : ControllerBase
    {
        public async Task<ActionResult> ChangeStyle([FromQuery]string style)
        {
            Response.Cookies.Append("style", style);
            return Redirect("/");

        }
    }
}
