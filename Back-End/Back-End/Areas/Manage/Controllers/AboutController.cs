using Back_End.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<About> abouts = _context.Abouts.ToList();

            return View(abouts);
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(About about)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            _context.Abouts.Add(about);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            About about = _context.Abouts.FirstOrDefault(x => x.Id ==id);

            if (about == null) return NotFound();
            return View(about);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {
            About ExistAbout = _context.Abouts.FirstOrDefault(x => x.Id == about.Id);

            if (ExistAbout == null) return NotFound();

            ExistAbout.Icon = about.Icon;
            ExistAbout.Title = about.Title;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
