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
    public interface iuserrepo
    {
        Task<List<user>> getall();
        Task<List<user>> gettablesbyid(int userid);
        user get(int id);

        user getbyname(string username);
        Task<user> create(user entity);
        Task<user> delete(int id);

        Task<user> update(int id, user entity);
    }

    public class userrepo : iuserrepo
    {

        private readonly ABcontext context;

        public userrepo(ABcontext context)
        {
            this.context = context;
        }

        public async Task<user> create(user entity)
        {
            context.user.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<user> delete(int id)
        {
            var user = await context.user.FindAsync(id);
            if (user == null)
            {
                return user;
            }

            this.context.user.Remove(user);
            await context.SaveChangesAsync();

            return user;
        }

        public user get(int id)
        {
            return context.user.FirstOrDefault((userobj) => userobj.userid == id);
        }

        public user getbyname(string username)
        {
            return context.user.FirstOrDefault((userobj) => userobj.username == username);
        }

        public Task<List<user>> getall()
        {
            return context.user.ToListAsync();
        }

        public async Task<List<user>> gettablesbyid(int userid)
        {
            List<user> list = new List<user>();
            list = await context.user.Where(userobj => userobj.userid == userid).Include(userobj => userobj.address).ToListAsync();
            return list;
        }

        public async Task<user> update(int id, user entity) // when updating include the other object as well
        {
            var user = await context.user.FindAsync(id);
            if (user == null)
            {
                return user;
            }

            user thisnewentity = new user()
            {
                password = entity.password,
                userid = entity.userid,
                username = entity.username
            };

            context.Entry(user).CurrentValues.SetValues(thisnewentity);
            context.SaveChangesAsync();

            return user;
        }
    }
}
