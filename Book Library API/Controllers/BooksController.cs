using Book_Library_API.Data;
using Book_Library_API.Models;
using Book_Library_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection;


namespace Book_Library_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext dbContext;

        public BooksController(LibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var book = dbContext.Books.ToList();

         var bookDtos=new List<BookDTO>();
            foreach (var books in book)
            {
                bookDtos.Add(new BookDTO()
                {
                    Id = books.Id,
                    Title = books.Title,
                    Author = books.Author,
                    Year = books.Year,
                    Genre = books.Genre
                })
             ;
            }

                return Ok(bookDtos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBooksById(int id)
        {
            var book = dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Genre = book.Genre
            };
                return Ok(book);
        }

        [HttpPost]
        [Route("{id:int}")]
        public IActionResult Create(CreateBookDTO createBookDTO)
        {
           
            var book = new Book
            {
                Title = createBookDTO.Title,
                Author = createBookDTO.Author,
                Year = createBookDTO.Year,
                Genre = createBookDTO.Genre
            };
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetBooksById), new { id = book.Id }, book);

        }
        //Update book details by id 
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, CreateBookDTO updateBookDTO)
        {
            var book = dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = updateBookDTO.Title;
            book.Author = updateBookDTO.Author;
            book.Year = updateBookDTO.Year;
            book.Genre = updateBookDTO.Genre;
            dbContext.SaveChanges();
            return Ok(book);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var book = dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
            return Ok(book);
        }
    }
}
