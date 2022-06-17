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
    public class productcontroller : ControllerBase
    {
        private readonly iproductrepo context;
        public productcontroller(iproductrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<product> postproduct(product product)
        {
            return await context.create(product);
        }

        [HttpGet("/api/getallproducts")]
        public async Task<IActionResult> getallproducts()
        {

            try
            {
                Task<List<product>> myresult = context.getall();

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteproduct(int id)
        {
            Task<product> productresult = context.delete(id);

            if (productresult.Result == null)
            {
                return NotFound();
            }

            return Ok(productresult.Result);
        }

        [HttpPut]
        public async Task<IActionResult> updateproduct(product product)
        {
            Task<product> productresult = context.update(product.productid, product);

            if (productresult.Result == null)
            {
                return NotFound();
            }

            return Ok(productresult.Result);
        }
    }
}