using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;
using System;
using WebApplication2.Service.Interface;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("sortedByPublisher")]
        public async Task<IActionResult> GetBooksSortedByPublisher()
        {          
            try
            {
                var result = await _bookService.GetBooksSortedByPublisher();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {               
                return StatusCode(400, ex.Message.ToString());
            }
        }

        [HttpGet("sortedByAuthor")]
        public async Task<IActionResult> GetBooksSortedByAuthor()
        {
            try
            {
                var result = await _bookService.GetBooksSortedByAuthor();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }
        }

        [HttpGet("sortedByPublisher/procedure")]
        public async Task<IActionResult> GetBookByPrcPublisher()
        {
            try
            {
                var result = await _bookService.GetBookByPrcPublisher();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }
        }

        [HttpGet("sortedByAuthor/procedure")]
        public async Task<IActionResult> GetBookByPrcAuthor()
        {
            try
            {
                var result = await _bookService.GetBookByPrcAuthor();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }
        }

        [HttpGet("getAllPrices")]
        public async Task<IActionResult> GetBookPrices()
        {
            try
            {
                var result = await _bookService.GetBookPrices();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }
        }

        [HttpPost("saveToDatabase")]
        public async Task<IActionResult> SaveBooksToDatabase(List<Book> books)
        {
            try
            {
                var result = await _bookService.SaveBooksToDatabase(books);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }
        }
    }
}
