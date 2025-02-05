using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bankmngsys.Models.Entities;  

namespace Bankmngsys.Controllers 
{
    public class CustomerController : Controller
    {
        private readonly Dbcon _context;

        public CustomerController(Dbcon applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // GET: Customer/Details/{id}
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer); // return the model if validation fails
        }

        // GET: Customer/Edit/{id}
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dbCustomer = _context.Customers.
                        SingleOrDefault(c => c.Id == id);
                    if (dbCustomer == null)
                    {
                        return NotFound();
                    }

                    dbCustomer.FirstName = customer.FirstName;
                    dbCustomer.LastName = customer.LastName;
                    dbCustomer.Email = customer.Email;
                    dbCustomer.Phone = customer.Phone;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    // Handle exception (e.g. log it)
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // POST: Customer/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // Handle exception (e.g. log it)
                return View();
            }
        }
    }
}
