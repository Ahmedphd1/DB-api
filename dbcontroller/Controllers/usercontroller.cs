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
using Microsoft.AspNetCore.Authorization;

namespace dbcontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usercontroller : ControllerBase
    {
        private readonly iuserrepo context;
        public usercontroller(iuserrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<user> postuser(user user)
        {
            return await context.create(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteuser(int id)
        {
            Task<user> myresult = context.delete(id);

            if (myresult.Result == null)
            {
                return NotFound();
            }

            return Ok(myresult.Result);
        }

        [HttpPut]
        public async Task<IActionResult> updateuser(user user)
        {
            Task<user> myresult = context.update(user.userid, user);

            if (myresult.Result == null)
            {
                return NotFound();
            }

            return Ok(myresult.Result);
        }

        [HttpGet("/api/getallusers")]
        public async Task<IActionResult> getallusers()
        {

            try
            {
                Task<List<user>> myresult = context.getall();

                if (myresult.Result == null)
                {
                    return Problem("no data");
                }

                if (myresult.Result.Count == 0)
                {
                    return NoContent();
                }

                return Ok(myresult.Result);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            //return await _context.Author.ToListAsync();
        }

        [HttpGet("/api/getuserbyid")]
        public async Task<IActionResult> get(int userid)
        {
            try
            {
                user myresult = context.get(userid);

                if (myresult == null)
                {
                    return Problem("no data");
                }

                return Ok(myresult);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("/api/getuserbyname")]
        public async Task<IActionResult> getbyname(string username)
        {
            try
            {
                user myresult = context.getbyname(username);

                if (myresult == null)
                {
                    return Problem("no data");
                }

                return Ok(myresult);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("/api/gettablesbyuser")]
        public async Task<IActionResult> getrelated(int userid)
        {

            try
            {
                Task<List<user>> myresult = context.gettablesbyid(userid);

                if (myresult.Result == null)
                {
                    return Problem("no data");
                }

                if (myresult.Result.Count == 0)
                {
                    return NoContent();
                }

                return Ok(myresult.Result);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            //return await _context.Author.ToListAsync();
        }
    }
}