using System.Security.Claims;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security;

namespace AuthNet.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {

        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return Ok(new { hello = "world" });
        }

        public IActionResult Authenticate()
        {
            var customers = new List<Customer>()
            {
                
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(new Claim[]{
                    
                })
            };

            return Ok();
        }

        public class Customer
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}