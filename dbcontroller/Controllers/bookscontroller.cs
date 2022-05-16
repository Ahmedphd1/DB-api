using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dblibrary;
using dblibrary.database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dbcontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookscontroller : ControllerBase
    {
        private readonly IBookRepository context;
        public bookscontroller(IBookRepository a)
        {
            context = a;
        }

        [HttpGet]
        public async Task<IActionResult> getallbooks()
        {

            try
            {
                Task<List<book>> myresult = context.getallbooks();

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

        [HttpPost]
        public async Task<book> postbook(book book)
        {
            return await context.createbook(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updatebook(int id, book book)
        {
            Task<book> bookresult = context.updatebook(id, book);

            if (bookresult.Result == null)
            {
                return NotFound();
            }

            return Ok(bookresult.Result);
        }

        //// DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletebook(int id)
        {
            Task<book> bookresult = context.delete(id);

            if (bookresult.Result == null)
            {
                return NotFound();
            }

            return Ok(bookresult.Result);
        }

        [HttpPost("{id}")]
        private IActionResult bookexsist(int id)
        {
            bool myresult = context.bookexsist(id);

            if (myresult == true)
            {
                return Ok(myresult);
            }
            else
            {
                return NotFound();
            }

        }
    }
}