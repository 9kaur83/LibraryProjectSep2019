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
    public class CustomersController : Controller
    {
        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(Library.GetAllCustomersByEmail(HttpContext.User.Identity.Name));
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = Library.GetCustomerByUserID(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,PhoneNumber,Email,Address,UserIDOfCustomer")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Library.CustomerInformation(customer.CustomerName, customer.PhoneNumber, customer.Email, customer.Address);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                
            {
                return NotFound();
            }

            var customer = Library.GetCustomerByUserID(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerName,PhoneNumber,Email,Address,UserIDOfCustomer")] Customer customer)
        {
            if (id != customer.UserIDOfCustomer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                Library.UpdateCustomer(customer);
                
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
   
    }
}
