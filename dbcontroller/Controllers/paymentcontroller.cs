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
    public class paymentcontroller : ControllerBase
    {
        private readonly ipaymentrepo context;
        public paymentcontroller(ipaymentrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<payment> postpayment(payment payment)
        {
            return await context.create(payment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletepayment(int id)
        {
            Task<payment> paymentresult = context.delete(id);

            if (paymentresult.Result == null)
            {
                return NotFound();
            }

            return Ok(paymentresult.Result);
        }

        [HttpGet("/api/getallpayments")]
        public async Task<IActionResult> getallusers()
        {

            try
            {
                Task<List<payment>> myresult = context.getall();

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

        [HttpPut]
        public async Task<IActionResult> updatepayment(payment payment)
        {
            Task<payment> paymentresult = context.update(payment.paymentid, payment);

            if (paymentresult.Result == null)
            {
                return NotFound();
            }

            return Ok(paymentresult.Result);
        }
    }
}