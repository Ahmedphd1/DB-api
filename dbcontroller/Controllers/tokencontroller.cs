using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dblibrary;
using dblibrary.database;
using dblibrary.repos;
using dblibrary.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace dbcontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tokencontroller : ControllerBase
    {
        public IConfiguration _configuration;
        public tokencontroller(IConfiguration a)
        {
            _configuration = a;
        }



        [HttpPost]
        public async Task<IActionResult> Post(string username, string password)
        {

            string defaultname = "ahmed";
            string defaultpass = "ahmed";

            if (username == defaultname && password == defaultpass)
            {

                //create claims details based on the user information
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWT:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("username", username),
                    new Claim("password", password),
                   };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));

            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
    }
}