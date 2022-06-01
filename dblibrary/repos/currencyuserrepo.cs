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
    public interface icurrencyuserrepo
    {
        Task<List<currencyuser>> getall();
        Task<List<currencyuser>> gettablesbyid(int userid);
        currencyuser get(int id);
        Task<currencyuser> create(currencyuser entity);
        Task<currencyuser> delete(int id);

        Task<currencyuser> update(int id, currencyuser entity);
    }

    public class currencyuserrepo : icurrencyuserrepo
    {

        private readonly ABcontext context;

        public currencyuserrepo(ABcontext context)
        {
            this.context = context;
        }

        public async Task<currencyuser> create(currencyuser entity)
        {
            context.currencyuser.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<currencyuser> delete(int id)
        {
            var currencyuser = await context.currencyuser.FindAsync(id);
            if (currencyuser == null)
            {
                return currencyuser;
            }

            this.context.currencyuser.Remove(currencyuser);
            await context.SaveChangesAsync();

            return currencyuser;
        }

        public currencyuser get(int id)
        {
            return context.currencyuser.FirstOrDefault((currencyuserobj) => currencyuserobj.userid == id);
        }

        public Task<List<currencyuser>> getall()
        {
            return context.currencyuser.ToListAsync();
        }

        public async Task<List<currencyuser>> gettablesbyid(int userid)
        {
            List<currencyuser> list = new List<currencyuser>();
            list = await context.currencyuser.Where(currencyuserobj => currencyuserobj.userid == userid).Include(currencyuserobj => currencyuserobj.user).Include(currencyuserobj => currencyuserobj.currency).ToListAsync();
            return list;
        }

        public async Task<currencyuser> update(int id, currencyuser entity) // when updating include the other object as well
        {
            var currencyuser = await context.currencyuser.FindAsync(id);
            if (currencyuser == null)
            {
                return currencyuser;
            }

            currencyuser thisnewentity = new currencyuser()
            {
                currencyid = entity.currencyid,
                userid = entity.userid
            };

            context.Entry(currencyuser).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return currencyuser;
        }
    }
}
