using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Exceptions;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Book;
using Librarian.Application.DTOs.Response;
using Librarian.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.WebAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] BookRequest newBookRequest)
        {
            var book = _bookService.InsertBook(newBookRequest);
            return Ok(new { status = "Your book was created", book.Uid });
        }

        [HttpGet]
        public IActionResult GetByUid(Guid Uid)
        {
            try
            {
                var request = new GetByIdRequest { Uid = Uid };
                var response = _bookService.GetById(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest(ex));
            }
        }

        [HttpDelete]
        public IActionResult DeleteBookByUid([FromBody] Guid id)
        {
            try
            {
                var delete = _bookService.DeleteBook(id);
                return Ok(new { status = "Deleted" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Name = "We didn't find this book in our inventory!", ex.StackTrace });
            }
        }

        [HttpPut]
        public IActionResult UpdateBook(UpdateBookRequest updatedBook)
        {
            try
            {
                var request = _bookService.UpdateBook(updatedBook);
                return Ok(new { status = "Updated", request.Uid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Name = "We didn't find this book in our inventory!", ex.StackTrace });
            }
        }

        [HttpGet]
        public ActionResult<List<BookResponse>> GetAll()
        {
            return Ok(_bookService.GetAll());
        }
    }
}