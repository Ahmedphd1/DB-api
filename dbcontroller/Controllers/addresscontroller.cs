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
    public class addresscontroller : ControllerBase
    {
        private readonly iaddressrepo context;
        public addresscontroller(iaddressrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<address> Postaddress(address book)
        {
            return await context.create(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteaddress(int id)
        {
            Task<address> authorresult = context.delete(id);

            if (authorresult.Result == null)
            {
                return NotFound();
            }

            return Ok(authorresult.Result);
        }

        [HttpPut]
        public async Task<IActionResult> Updatedelivery(address address)
        {
            Task<address> addressresult = context.update(address.userid, address);

            if (addressresult.Result == null)
            {
                return NotFound();
            }

            return Ok(addressresult.Result);
        }
    }
}