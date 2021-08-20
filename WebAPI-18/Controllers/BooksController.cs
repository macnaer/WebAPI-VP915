using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_18.Data.Models;
using WebAPI_18.Data.Services;

namespace WebAPI_18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        //[HttpPut("update-book/{id}")]
        //public IActionResult UpdateBook(int id, [FromBody] Book book)
        //{
        //    var updatedBook = _bookService.UpdateBook(id, book);
        //    return Ok(updatedBook);
        //}

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
