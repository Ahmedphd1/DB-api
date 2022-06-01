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
    public class sellercontroller : ControllerBase
    {
        private readonly isellerrepo context;
        public sellercontroller(isellerrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<seller> postseller(seller seller)
        {
            return await context.create(seller);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteseller(int id)
        {
            Task<seller> sellerresult = context.delete(id);

            if (sellerresult.Result == null)
            {
                return NotFound();
            }

            return Ok(sellerresult.Result);
        }

        [HttpPut]
        public async Task<IActionResult> updateseller(seller seller)
        {
            Task<seller> sellerresult = context.update(seller.sellerid, seller);

            if (sellerresult.Result == null)
            {
                return NotFound();
            }

            return Ok(sellerresult.Result);
        }

        [HttpGet("/api/getallsellers")]
        public async Task<IActionResult> getallsellers()
        {

            try
            {
                Task<List<seller>> myresult = context.getall();

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

        [HttpGet("/api/getsellerbyid")]
        public async Task<IActionResult> get(int sellerid)
        {
            try
            {
                seller myresult = context.get(sellerid);

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

        [HttpGet("/api/gettablesbyseller")]
        public async Task<IActionResult> getrelated(int sellerid)
        {

            try
            {
                Task<List<seller>> myresult = context.gettablesbyid(sellerid);

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