using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using Newtonsoft.Json;
using PsJwt.Web.Models;

namespace PsJwt.Web.Api
{
    public class AuthController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]RegisterPostViewModel userModel)
        {
            var jwtService = new JwtService();
            var payload = new JwtPayload() {Iss = "localhost", Sub = userModel.Email};

            var jwt = jwtService.Encode(payload, "shh..");

            return Ok(new RegisterResponseModel() {Token = jwt, User = new User() {Email = userModel.Email}});

        }
    }

    public class RegisterPostViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class JwtService
    {
        public string Encode<T>(T payload, string secret)
        {
            var header = new JwtHeader() {Alg = "HS256", Typ = "JWT"};

            var headerJson = Json.Encode(header) ;
            var payloadJson = Json.Encode(payload);

            var jwt = headerJson.ToBase64() + '.' + payloadJson.ToBase64();

            jwt += "." + Sign(jwt, secret);

            return jwt;
        }

        private string Sign(string jwt, string secret)
        {
            var hmac = new HMACSHA256();

            hmac.Key = Encoding.UTF8.GetBytes(secret);

            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(jwt));

            return Encoding.UTF8.GetString(hash).ToBase64();
        }
    }

    public static class StringExtensions
    {
        public static string ToBase64(this string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }

    public class JwtHeader
    {
        public string Typ { get; set; }
        public string Alg { get; set; }
    }

    public class JwtPayload
    {
        public string Iss { get; set; }
        public string Sub { get; set; }
    }

    public class RegisterResponseModel
    {
        public User User { get; set; }
        public string Token { get; set; }
    }

    public class User
    {
        public string Email { get; set; }
    }
}