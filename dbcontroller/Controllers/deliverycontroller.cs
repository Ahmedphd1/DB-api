using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dblibrary;
using dblibrary.database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public class deliverycontroller : ControllerBase
    {
        private readonly ideliveryrepo context;
        public deliverycontroller(ideliveryrepo a)
        {
            context = a;
        }

        [HttpPost]
        public async Task<delivery> Postdelivery(delivery delivery)
        {
            return await context.create(delivery);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletedelivery(int id)
        {
            Task<delivery> deliveryresult = context.delete(id);

            if (deliveryresult.Result == null)
            {
                return NotFound();
            }

            return Ok(deliveryresult.Result);
        }

        [HttpPut]
        public async Task<IActionResult> Updatedelivery(delivery delivery)
        {
            Task<delivery> deliveryresult = context.update(delivery.deliveryid, delivery);

            if (deliveryresult.Result == null)
            {
                return NotFound();
            }

            return Ok(deliveryresult.Result);
        }
    }
}