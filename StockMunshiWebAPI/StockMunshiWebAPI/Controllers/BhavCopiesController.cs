using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMunshiWebAPI.Models;

namespace StockMunshiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BhavCopiesController : ControllerBase
    {
        private readonly BhavCopiesContext _context;

        public BhavCopiesController(BhavCopiesContext context)
        {
            _context = context;

            //if (_context.BhavCopies.Count() == 0)
            //{
            //    // Create a new TodoItem if collection is empty,
            //    // which means you can't delete all TodoItems.
            //    _context.TodoItems.Add(new TodoItem { Name = "Item1" });
            //    _context.SaveChanges();
            //}
        }

        //[HttpGet]
        //public ActionResult<List<BhavCopies>> GetAll()
        //{
        //    return _context.BhavCopies.Where(c => c.Ticker == "HDFC").ToList();
        //}

        [HttpGet]
        public ActionResult<List<BhavCopies>> GetAllBhavs(string Ticker)
        {
            return _context.BhavCopies.Where(c => c.Ticker == Ticker).ToList();
        }
    }
}