using Back_End.Model;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public ShopController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(int page=1)
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                Products = _context.Products.Include(x => x.ProductImages).
                Include(x => x.Status).Include(x => x.City).Include(x => x.Team).Skip((page - 1) * 4).Take(4).ToList(),
                Statuses = _context.Statuses.ToList(),
                Categories = _context.Categories.ToList(),
            };
            ViewBag.TotalPage = Math.Ceiling(_context.Teams.Count() / 4m);
            ViewBag.SelectedPage = page;
            return View(shopVM);
        }


        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(int id,Review review)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            Review newReview = new Review
            {
                Email = review.Email,
                Username = review.Username,
                Rate = 1,
                Date = DateTime.UtcNow,
                Text = review.Text,
                ProductId =id,
                AppUserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id

            };

            
            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }
    }
}
