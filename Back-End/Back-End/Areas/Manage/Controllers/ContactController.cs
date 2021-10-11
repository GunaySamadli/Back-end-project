using Back_End.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = _context.Contacts.ToList();

            return View(contacts);
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null) return NotFound();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            Contact ExistContact = _context.Contacts.FirstOrDefault(x => x.Id == contact.Id);

            if (ExistContact == null) return NotFound();

            ExistContact.Icon = contact.Icon;
            ExistContact.Title = contact.Title;
            ExistContact.Desc1 = contact.Desc1;
            ExistContact.Desc2 = contact.Desc2;


            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null) return Json(new { status = 404 });

            try
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }
    }
}
