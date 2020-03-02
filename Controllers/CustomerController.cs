using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuthNet.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AuthNet.Controllers
{
    [ApiController]
    [Route("customer")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly AuthContext _context;
        public CustomerController(AuthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var cu = _context.Customers;
            return Ok(new {message = "success retrieve data", status = true, data = cu});
        }

        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customers.First(i => i.Id == id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _context.Customers.First(i => i.Id == id);
            customer.FullName = "Na Dul Set";
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.First(i => i.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
    }
}