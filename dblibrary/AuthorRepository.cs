using Microsoft.EntityFrameworkCore;
using dblibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dblibrary.database;

namespace dblibrary
{
    //Why!! - polymorf, Unit test, og abstract tænkning
    public interface IAuthorRepository
    {
        Task<List<author>> getAllAuthors();
        author getAuthor(int authorId);
        Task<author> createAuthor(author author);
        Task<author> delete(int authorId);

        Task<author> updateauthor(int authorid, author newauthor);

        bool authorexsist(int authorid);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private readonly ABcontext context;

        public AuthorRepository(ABcontext context)
        {
            this.context = context;
        }

        public Task<List<author>> getAllAuthors() {
            return context.author.ToListAsync();
        }
 
        public author getAuthor(int authorId)
        {
            return context.author.FirstOrDefault((authorObj) => authorObj.authorid == authorId);
        }
        public async Task<author> createAuthor(author author) {
            context.author.Add(author);
            await context.SaveChangesAsync();
            return author;

        }
        public async Task<author> delete(int authorId) {

            var author = await context.author.FindAsync(authorId);
            if (author == null)
            {
                return author;
            }

            this.context.author.Remove(author);
            await context.SaveChangesAsync();

            return author;
        }

        public async Task<author> updateauthor(int authorId, author newauthor)
        {

            var author = await context.author.FindAsync(authorId);
            if (author == null)
            {
                return author;
            }

           author thisnewauthor = new author()
            {
                authorid = authorId,
                age = newauthor.age,
                isalive = newauthor.isalive,
                name = newauthor.name,
                password = newauthor.password
            };

            System.Diagnostics.Debug.WriteLine(author.name);

            context.Entry(author).CurrentValues.SetValues(thisnewauthor);
            context.SaveChangesAsync();

            return author;
        }

        public bool authorexsist(int authorid)
        {

            return context.author.Any(e => e.authorid == authorid);
        }
    }
}
