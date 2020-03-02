using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security;
using AuthNet.Models;  

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

        [HttpGet]
        public IActionResult Authenticate(Customer customer)
        {
            var customers = new List<Customer>()
            {
                
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(new Claim[]{
        
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("")), SecurityAlgorithms.HmacSha512Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescription);
            return Ok(token);
        }
    }
}