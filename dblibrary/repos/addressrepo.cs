using Microsoft.EntityFrameworkCore;
using dblibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dblibrary.database;
using dblibrary.models;

namespace dblibrary.repos
{
    //Why!! - polymorf, Unit test, og abstract tænkning
    public interface iaddressrepo
    {
        Task<address> create(address entity);
        Task<address> delete(int id);

        Task<address> update(int id, address entity);
    }

    public class addressrepo : iaddressrepo
    {

        private readonly ABcontext context;

        public addressrepo(ABcontext context)
        {
            this.context = context;
        }

        public async Task<address> create(address entity)
        {
            context.address.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<address> delete(int id)
        {
            var address = await context.address.FindAsync(id);
            if (address == null)
            {
                return address;
            }

            this.context.address.Remove(address);
            await context.SaveChangesAsync();

            return address;
        }

        public async Task<address> update(int id, address entity) // when updating include the other object as well
        {
            var address = await context.address.FindAsync(id);
            if (address == null)
            {
                return address;
            }

            address thisnewentity = new address()
            {
                country = entity.country,
                userid = entity.userid,
                zipcode = entity.zipcode
            };

            context.Entry(address).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return address;
        }
    }
}
