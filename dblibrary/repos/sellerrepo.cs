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
    public interface isellerrepo
    {
        Task<List<seller>> getall();

        Task<List<seller>> gettablesbyid(int sellerid);
        seller get(int id);
        Task<seller> create(seller entity);
        Task<seller> delete(int id);

        Task<seller> update(int id, seller entity);
    }

    public class sellerrepo : isellerrepo
    {

        private readonly ABcontext context;

        public sellerrepo(ABcontext context)
        {
            this.context = context;
        }

        public async Task<seller> create(seller entity)
        {
            context.seller.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<seller> delete(int id)
        {
            var seller = await context.seller.FindAsync(id);
            if (seller == null)
            {
                return seller;
            }

            this.context.seller.Remove(seller);
            await context.SaveChangesAsync();

            return seller;
        }

        public seller get(int id)
        {
            return context.seller.FirstOrDefault((sellerobj) => sellerobj.sellerid == id);
        }

        public Task<List<seller>> getall()
        {
            return context.seller.ToListAsync();
        }

        public async Task<List<seller>> gettablesbyid(int sellerid)
        {
            List<seller> list = new List<seller>();
            list = await context.seller.Where(sellerobj => sellerobj.sellerid == sellerid).Include(sellerobj => sellerobj.product).ToListAsync();
            return list;
        }

        public async Task<seller> update(int id, seller entity) // when updating include the other object as well
        {
            var seller = await context.seller.FindAsync(id);
            if (seller == null)
            {
                return seller;
            }

            seller thisnewentity = new seller()
            {
                name = entity.name,
                sellerid = entity.sellerid
            };

            context.Entry(seller).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return seller;
        }
    }
}
