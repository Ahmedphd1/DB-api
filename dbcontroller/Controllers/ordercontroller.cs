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
    public class ordercontroller : ControllerBase
    {
        private readonly iordersrepo context;
        public ordercontroller(iordersrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<orders> Postorder(orders order)
        {
            return await context.create(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteorder(int id)
        {
            Task<orders> orderresult = context.delete(id);

            if (orderresult.Result == null)
            {
                return NotFound();
            }

            return Ok(orderresult.Result);
        }

        [HttpPut]
        public async Task<IActionResult> updateorder(orders order)
        {
            Task<orders> orderresult = context.update(order.orderid, order);

            if (orderresult.Result == null)
            {
                return NotFound();
            }

            return Ok(orderresult.Result);
        }

        [HttpGet("/api/getallorders")]
        public async Task<IActionResult> getallorders()
        {

            try
            {
                Task<List<orders>> myresult = context.getall();

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

        [HttpGet("/api/getorderbyid")]
        public async Task<IActionResult> get(int orderid)
        {
            try
            {
                orders myresult = context.get(orderid);

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

        [HttpGet("/api/gettablesbyuserid")]
        public async Task<IActionResult> getrelated(int userid)
        {

            try
            {
                Task<List<orders>> myresult = context.gettablesbyid(userid);

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