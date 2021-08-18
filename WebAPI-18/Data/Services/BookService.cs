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
    }
}
