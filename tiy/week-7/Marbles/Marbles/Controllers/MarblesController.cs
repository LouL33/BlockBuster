using Marbles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marbles.Controllers
{
    public class MarblesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(new { Hello = "world" });
        }


        [HttpPost]
        public IHttpActionResult AddMarbles(MarblesWithColor marbles)
        {
            marbles.Id = new Random().Next(0, 100);
            marbles.Color = "white";
            return Ok(marbles);
        }

    }
}
