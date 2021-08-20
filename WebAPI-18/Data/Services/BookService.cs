using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_18.Data.Models;
using WebAPI_18.Data.ViewModels;

namespace WebAPI_18.Data.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public void AddBookWithAuthors(BookVM book)
        {

            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                ImageURL = book.ImageURL,
                DateAdded = book.DateAdded,
                PublisherId = book.PublisherId
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }


        //public void AddBook(Book book)
        //{
        //    _db.Books.Add(book);
        //    _db.SaveChanges();
        //}

        //public Book UpdateBook(int bookId, Book book)
        //{
        //    var _book = _db.Books.FirstOrDefault(n => n.Id == bookId);

        //    if(_book != null)
        //    {
        //        _book.Title = book.Title;
        //        _book.Description = book.Description;
        //        _book.IsRead = book.IsRead;
        //        _book.DateRead = book.DateRead;
        //        _book.Rate = book.Rate;
        //        _book.Genre = book.Genre;
        //        _book.ImageURL = book.ImageURL;
        //        _book.DateAdded = book.DateAdded;
        //        _book.Author = book.Author;
        //        _db.SaveChanges();
        //    }

        //    return _book;
        //}

        public void DeleteBook(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
