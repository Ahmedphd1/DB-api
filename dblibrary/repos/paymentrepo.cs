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
    public interface ipaymentrepo
    {
        Task<payment> create(payment entity);
        Task<payment> delete(int id);

        Task<payment> update(int id, payment entity);
    }

    public class paymentrepo : ipaymentrepo
    {

        private readonly ABcontext context;

        public paymentrepo(ABcontext context)
        {
            this.context = context;
        }

        public async Task<payment> create(payment entity)
        {
            context.payment.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<payment> delete(int id)
        {
            var payment = await context.payment.FindAsync(id);
            if (payment == null)
            {
                return payment;
            }

            this.context.payment.Remove(payment);
            await context.SaveChangesAsync();

            return payment;
        }

        public async Task<payment> update(int id, payment entity) // when updating include the other object as well
        {
            var payment = await context.payment.FindAsync(id);
            if (payment == null)
            {
                return payment;
            }

            payment thisnewentity = new payment()
            {
                method = entity.method,
                paymentid = entity.paymentid
            };

            context.Entry(payment).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return payment;
        }
    }
}
