
using Back_End.Model;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = _context.Sliders.OrderBy(x=>x.Order).ToList(),
                Abouts = _context.Abouts.ToList(),
                Services = _context.Services.Take(3).ToList(),
                Tags=_context.Tags.ToList(),
                Statuses=_context.Statuses.ToList(),
                Cities=_context.Cities.ToList(),
                Categories=_context.Categories.ToList(),
                FeaturedProduct = _context.Products.Include(x=>x.ProductImages).
                 Include(x => x.Status).Include(x => x.City).Include(x => x.Team).
                 Where(x=>x.IsFeatured).ToList()
            };
            return View(homeVM);
        }

        
    }
}
