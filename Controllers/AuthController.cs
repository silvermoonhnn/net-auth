using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthNet.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Authenticate(Auth auth)
        {
            var auths = new List<Auth>()
            {
                new Auth() { Username="hahaha", Pass="cobain"},
                new Auth() { Username="hahaha", Pass="cobain"}
            };

            var _auth = auths.Find(e => e.Username == auth.Username);

            var tokenHandler = new JwtSecurityTokenHandler();
            
             var tokenDescription = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, _auth.Username),
                    new Claim(ClaimTypes.Name, _auth.Pass)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("")), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenResponse = new
            {
                token = tokenHandler.WriteToken(token),
                auth = _auth.Username
            };

            return Ok(tokenResponse);
        }
    }
}