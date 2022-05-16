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

    public interface IBookRepository
    {
        Task<List<book>> getallbooks();
        book getbook(int bookid);
        Task<book> createbook(book book);
        Task<book> delete(int bookid);

        Task<book> updatebook(int bookid, book newbook);

        bool bookexsist(int bookid);
    }

    public class bookRepository : IBookRepository
    {
        private readonly ABcontext context;

        public bookRepository(ABcontext context)
        {
            this.context = context;
        }

        public Task<List<book>> getallbooks()
        {
            return context.book.ToListAsync();
        }

        public book getbook(int bookid)
        {
            return context.book.FirstOrDefault((bookobj) => bookobj.bookid == bookid);
        }
        public async Task<book> createbook(book book)
        {
            context.book.Add(book);
            await context.SaveChangesAsync();
            return book;

        }
        public async Task<book> delete(int bookid)
        {

            var book = await context.book.FindAsync(bookid);
            if (book == null)
            {
                return book;
            }

            this.context.book.Remove(book);
            await context.SaveChangesAsync();

            return book;
        }

        public bool bookexsist(int bookid)
        {
            return context.book.Any(e => e.bookid == bookid);
        }

        public async Task<book> updatebook(int bookid, book newbook)
        {
            var book = await context.book.FindAsync(bookid);
            if (book == null)
            {
                return book;
            }

            book thisnewbook = new book()
            {
                bookid = bookid,
                binding = newbook.binding,
                pages = newbook.pages,
                releaseyear = newbook.releaseyear,
                title = newbook.title,
                wordcount = newbook.wordcount
            };

            context.Entry(book).CurrentValues.SetValues(thisnewbook);
            context.SaveChangesAsync();

            return book;
        }
    }
}
