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

namespace dbcontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class currencyusercontroller : ControllerBase
    {
        private readonly icurrencyuserrepo context;
        public currencyusercontroller(icurrencyuserrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<currencyuser> postuser(currencyuser currencyuser)
        {
            return await context.create(currencyuser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletecurrencyuser(int id)
        {
            Task<currencyuser> myresult = context.delete(id);

            if (myresult.Result == null)
            {
                return NotFound();
            }

            return Ok(myresult.Result);
        }

        [HttpPut]
        public async Task<IActionResult> updatecurrencyuser(currencyuser currencyuser)
        {
            Task<currencyuser> myresult = context.update(currencyuser.currencyuserid, currencyuser);

            if (myresult.Result == null)
            {
                return NotFound();
            }

            return Ok(myresult.Result);
        }

        [HttpGet("/api/getallcurrencyuser")]
        public async Task<IActionResult> getallusers()
        {

            try
            {
                Task<List<currencyuser>> myresult = context.getall();

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

        [HttpGet("/api/getcurrencyuserbyid")]
        public async Task<IActionResult> get(int currencyuserid)
        {
            try
            {
                currencyuser myresult = context.get(currencyuserid);

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

        [HttpGet("/api/gettablesbyusercurrency")]
        public async Task<IActionResult> getrelated(int userid)
        {

            try
            {
                Task<List<currencyuser>> myresult = context.gettablesbyid(userid);

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