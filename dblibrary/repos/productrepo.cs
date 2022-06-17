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
    public interface iproductrepo
    {
        Task<List<product>> getall();
        Task<product> create(product entity);
        Task<product> delete(int id);

        Task<product> update(int id, product entity);
    }

    public class productrepo : iproductrepo
    {

        private readonly ABcontext context;

        public productrepo(ABcontext context)
        {
            this.context = context;
        }

        public Task<List<product>> getall()
        {
            return context.product.ToListAsync();
        }

        public async Task<product> create(product entity)
        {
            context.product.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<product> delete(int id)
        {
            var product = await context.product.FindAsync(id);
            if (product == null)
            {
                return product;
            }

            this.context.product.Remove(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<product> update(int id, product entity) // when updating include the other object as well
        {
            var product = await context.product.FindAsync(id);
            if (product == null)
            {
                return product;
            }

            product thisnewentity = new product()
            {
                productid = entity.productid,
                price = entity.price,
                productname = entity.productname,
            };

            context.Entry(product).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return product;
        }
    }
}
