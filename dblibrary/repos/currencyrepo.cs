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
    public interface icurrencyrepo
    {
        Task<currency> create(currency entity);
        Task<currency> delete(int id);

        Task<currency> update(int id, currency entity);
    }

    public class currencyrepo : icurrencyrepo
    {

        private readonly ABcontext context;

        public currencyrepo(ABcontext context)
        {
            this.context = context;
        }

        public async Task<currency> create(currency entity)
        {
            context.currency.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<currency> delete(int id)
        {
            var currency = await context.currency.FindAsync(id);
            if (currency == null)
            {
                return currency;
            }

            this.context.currency.Remove(currency);
            await context.SaveChangesAsync();

            return currency;
        }

        public async Task<currency> update(int id, currency entity) // when updating include the other object as well
        {
            var currency = await context.currency.FindAsync(id);
            if (currency == null)
            {
                return currency;
            }

            currency thisnewentity = new currency()
            {
                currencyid = entity.currencyid,
                currencyname = entity.currencyname,
            };

            context.Entry(currency).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return currency;
        }
    }
}
