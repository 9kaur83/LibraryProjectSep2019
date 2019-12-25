using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryProjectSep2019;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace LibraryUI.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {

        public string username { get; set; }
        // GET: Books
        public IActionResult Index()
        {
            if (HttpContext != null && !string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                username = HttpContext.User.Identity.Name;
            }

            return View(Library.GetAllBooks(username));
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
                Library.BookInformation(book.BookName, book.IsbnNumber, book.BooksCategory, book.ReplacementPrice);
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

        [HttpPost]
        public IActionResult bookIssue(IFormCollection controls)
        {
            var IsbnNumber = controls["IsbnNumber"];
            var email = this.User.Identity.Name;
            var bookName = controls["bookName"];

            Library.IssueBook(email, bookName);

            return RedirectToAction(nameof(Index));
        }
        //Get
        public IActionResult bookReturn(String id)
        {
            if (id == null)
                return NotFound();

           var book = Library.GetBookByIsbnNumber(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult bookReturn(IFormCollection controls)
        {
            var IsbnNumber = controls["IsbnNumber"];
            var bookName = controls["bookName"];

            Library.ReturnBook(bookName);

            return RedirectToAction(nameof(Index));
        }

        //Get
        public IActionResult Transactions(String id)
        {
            if (id == null)
                return NotFound();
            var email = this.User.Identity.Name;
            var transactions = Library.GetAllTransactionByEmail(email);

           
            return View(transactions);
        }
    }
}

   
