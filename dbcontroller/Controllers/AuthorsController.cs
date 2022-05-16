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
    public class authorcontroller : ControllerBase
    {
        private readonly IAuthorRepository context;
        public authorcontroller(IAuthorRepository a)
        {
            context = a;
        }
        // GET: api/Authors
        [HttpGet]
        public async Task<IActionResult> getallauthors()
        {

            try
            {
                Task<List<author>> myresult = context.getAllAuthors();

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
        public async Task<author> PostAuthor(author author)
        {
            return await context.createAuthor(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateauthor(int id, author author)
        {
            Task<author> authorresult = context.updateauthor(id, author);

            if (authorresult.Result == null)
            {
                return NotFound();
            }

            return Ok(authorresult.Result);
        }

        //// DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            Task<author> authorresult = context.delete(id);

            if (authorresult.Result == null)
            {
                return NotFound();
            }

            return Ok(authorresult.Result);
        }

        [HttpPost("{id}")]
        private IActionResult AuthorExists(int id)
        {
            bool myresult = context.authorexsist(id);

            if (myresult == true)
            {
              return Ok(myresult);
            } else
            {
                return NotFound();
            }

        }
    }
}