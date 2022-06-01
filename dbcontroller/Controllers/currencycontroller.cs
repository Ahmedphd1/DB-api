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
    public class currencycontroller : ControllerBase
    {
        private readonly icurrencyrepo context;
        public currencycontroller(icurrencyrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<currency> postseller(currency currency)
        {
            return await context.create(currency);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletecurrency(int id)
        {
            Task<currency> currencyresult = context.delete(id);

            if (currencyresult.Result == null)
            {
                return NotFound();
            }

            return Ok(currencyresult.Result);
        }

        [HttpPut]
        public async Task<IActionResult> updatecurrency(currency currency)
        {
            Task<currency> currencyresult = context.update(currency.currencyid, currency);

            if (currencyresult.Result == null)
            {
                return NotFound();
            }

            return Ok(currencyresult.Result);
        }
    }
}