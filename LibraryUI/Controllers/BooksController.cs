using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryProjectSep2019;
using Microsoft.AspNetCore.Authorization;

namespace LibraryUI.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
       

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(Library.GetAllBooks());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = Library.GetBookByIsbnNumber(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookName,IsbnNumber,IssuedUserID,IssuedDate,BooksCategory,ReplacementPrice")] Book book)
        {
            if (ModelState.IsValid)
            {
                Library.BookInformation(book.BookName,book.IsbnNumber,book.BooksCategory,book.ReplacementPrice);
                return RedirectToAction(nameof(Index));
            }   
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = Library.GetBookByIsbnNumber(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BookName,IsbnNumber,IssuedUserID,IssuedDate,BooksCategory,ReplacementPrice")] Book book)
        {
            if (id != book.IsbnNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                Library.UpdateBook(book);
                
              
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
       
        //Get
        public IActionResult bookIssue(String id)
        {
            if (id == null)
                return NotFound();

            var book = Library.GetBookByIsbnNumber(id);
            if (book == null)
                return NotFound();

            return View(book);
        }    
    }
}
