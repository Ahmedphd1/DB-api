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
    public interface ideliveryrepo
    {
        Task<delivery> create(delivery entity);
        Task<delivery> delete(int id);

        Task<delivery> update(int id, delivery entity);
    }

    public class deliveryrepo : ideliveryrepo
    {

        private readonly ABcontext context;

        public deliveryrepo(ABcontext context)
        {
            this.context = context;
        }

        public async Task<delivery> create(delivery entity)
        {
            context.delivery.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<delivery> delete(int id)
        {
            var delivery = await context.delivery.FindAsync(id);
            if (delivery == null)
            {
                return delivery;
            }

            this.context.delivery.Remove(delivery);
            await context.SaveChangesAsync();

            return delivery;
        }

        public async Task<delivery> update(int id, delivery entity) // when updating include the other object as well
        {
            var delivery = await context.delivery.FindAsync(id);
            if (delivery == null)
            {
                return delivery;
            }

            delivery thisnewentity = new delivery()
            {
                deliveryid = entity.deliveryid,
                method = entity.method,
            };

            context.Entry(delivery).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return delivery;
        }
    }
}
