
using Back_End.Model;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            
            string strPr=HttpContext.Request.Cookies["Product"];
            ViewBag.Favorites = null;
            if (strPr!=null)
            {
                ViewBag.Favorites = JsonConvert.DeserializeObject<List<FavItemViewModel>>(strPr);

            }

            

            HomeViewModel homeVM = new HomeViewModel
            {
                LastProduct=_context.Orders.Include(x=>x.Product)
                .ThenInclude(x=>x.ProductImages).OrderByDescending(x=>x.Id).FirstOrDefault(),
                Sliders = _context.Sliders.OrderBy(x=>x.Order).ToList(),
                Abouts = _context.Abouts.ToList(),
                Services = _context.Services.Take(3).ToList(),
                Tags=_context.Tags.ToList(),
                Statuses=_context.Statuses.ToList(),
                Cities=_context.Cities.ToList(),
                Settings = _context.Settings.ToList(),
                Categories = _context.Categories.ToList(),
                FeaturedProduct = _context.Products.Include(x=>x.ProductImages).
                 Include(x => x.Status).Include(x => x.City).Include(x => x.Team).
                 Where(x=>x.IsFeatured).ToList()
            };
            return View(homeVM);
        }

        public IActionResult GetProduct(int id)
        {
            Product product = _context.Products
                .Include(x => x.ProductImages).Include(x => x.Category)
                .Include(x => x.Status).Include(x => x.City)
                .Include(x => x.ProductTags).ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == id);

            return PartialView("_ProductModalView", product);
        }

        public IActionResult Search(string search)
        {
            var query = _context.Products.Include(x => x.ProductImages).Include(x => x.City)
                                            .Include(x => x.Team).Include(x => x.Status)
                                            .Include(x => x.ProductTags)
                                            .ThenInclude(x => x.Tag).AsQueryable()
                                            .Where(x => x.Name.Contains(search));
            List<Product> products = query.OrderByDescending(x=>x.Id).Take(3).ToList();
            return PartialView("_SearchPartial",products);
        }

    }
}
