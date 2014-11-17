using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.WebSockets;
using Microsoft.Ajax.Utilities;

namespace PsJwt.Web.Api
{
    public class JobsController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {

            var jwtService = new JwtService();

            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];

            if (authHeader == null)
            {
                return Unauthorized();
            }

            var token = authHeader.Split(' ')[1];

            jwtService.Decode(token, "shh..");

            var result = new string[] {"Cook", "SuperHero", "Unicorn Wisperer", "Toast Inspector"};

            return Ok(result);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}