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
    public interface iordersrepo
    {
        Task<List<orders>> getall();

        Task<List<orders>> gettablesbyid(int userid);

        orders get(int id);
        Task<orders> create(orders entity);
        Task<orders> delete(int id);

        Task<orders> update(int id, orders entity);
    }

    public class ordersrepo : iordersrepo
    {

        private readonly ABcontext context;

        public ordersrepo(ABcontext context)
        {
            this.context = context;
        }

        public async Task<orders> create(orders entity)
        {
            context.orders.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<orders> delete(int id)
        {
            var orders = await context.orders.FindAsync(id);
            if (orders == null)
            {
                return orders;
            }

            this.context.orders.Remove(orders);
            await context.SaveChangesAsync();

            return orders;
        }

        public orders get(int id)
        {
            return context.orders.FirstOrDefault((ordersobj) => ordersobj.orderid == id);
        }

        public Task<List<orders>> getall()
        {
            return context.orders.ToListAsync();
        }

        public async Task<List<orders>> gettablesbyid(int userid)
        {
            List<orders> list = new List<orders>();
            list = await context.orders.Where(orderobj => orderobj.userid == userid).Include(orderobj => orderobj.user)
            .Include(orderobj => orderobj.user)
            .Include(orderobj => orderobj.product)
            .Include(orderobj => orderobj.delivery)
            .Include(orderobj => orderobj.payment).ToListAsync();
            return list;
        }

        public async Task<orders> update(int id, orders entity) // when updating include the other object as well
        {
            var orders = await context.orders.FindAsync(id);
            if (orders == null)
            {
                return orders;
            }

            orders thisnewentity = new orders()
            {
                deliveryid = entity.deliveryid,
                orderid = entity.orderid,
                paymentid = entity.paymentid,
                productid = entity.productid,
                userid = entity.userid
            };

            context.Entry(orders).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return orders;
        }
    }
}
