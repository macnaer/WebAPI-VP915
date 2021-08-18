using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_18.Data.Models;

namespace WebAPI_18.Data.Services
{
    public class BookService
    {
        private readonly AppDbContext _db;
        public BookService(AppDbContext db)
        {
            _db = db;
        }

        public List<Book> GetAllBooks() => _db.Books.ToList();

        public void AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public Book UpdateBook(int bookId, Book book)
        {
            var _book = _db.Books.FirstOrDefault(n => n.Id == bookId);

            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.ImageURL = book.ImageURL;
                _book.DateAdded = book.DateAdded;
                _book.Author = book.Author;
                _db.SaveChanges();
            }

            return _book;
        }

        public void DeleteBook(int bookId)
        {
            var _book = _db.Books.FirstOrDefault(n => n.Id == bookId);
            
            if(_book != null)
            {
                _db.Books.Remove(_book);
                _db.SaveChanges();
            }
        }
    }
}
