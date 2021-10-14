using Back_End.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Areas.Manage.Controllers
{
    [Area("manage")]
   
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;
        public ReviewController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Review> reviews = _context.Reviews.Include(x=>x.AppUser).ToList();

            return View(reviews);
        }
        public IActionResult Detail(int id)
        {
            Review review =_context.Reviews.Include(x => x.AppUser).Include(x=>x.Product).FirstOrDefault(x=>x.Id==id);

            return View(review);
        }

      
        public IActionResult Accept(int id)
        {
            Review review = _context.Reviews.Include(x => x.AppUser).Include(x => x.Product).FirstOrDefault(x => x.Id == id);
            if (review == null) return NotFound();

            review.Accept = true;
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Review review = _context.Reviews.FirstOrDefault(x => x.Id == id);

            if (review == null) return Json(new { status = 404 });

            try
            {
                _context.Reviews.Remove(review);
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
